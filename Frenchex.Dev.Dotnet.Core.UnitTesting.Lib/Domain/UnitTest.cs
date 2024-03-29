﻿#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using System.Diagnostics;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using Frenchex.Dev.Dotnet.Core.Tooling.TimeSpan.Lib.Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Frenchex.Dev.Dotnet.Core.UnitTesting.Lib.Domain;

public class UnitTest : IAsyncDisposable
{
    private readonly Action<IConfigurationBuilder> _configureConfigurationFunc;
    private readonly Action<IServiceCollection, IConfigurationRoot>? _configureMocksFunc;
    private readonly Action<IServiceCollection, IConfigurationRoot>? _configureServicesFunc;
    private bool _alreadyBuild;
    private VsCodeDebugging? _vsCodeDebugging;

    public UnitTest(
        Action<IConfigurationBuilder> configureConfigurationFunc,
        Action<IServiceCollection, IConfigurationRoot>? configureServicesFunc,
        Action<IServiceCollection, IConfigurationRoot>? configureMocksFunc
    )
    {
        _configureConfigurationFunc = configureConfigurationFunc;
        _configureServicesFunc = configureServicesFunc;
        _configureMocksFunc = configureMocksFunc;
    }

    private IServiceProvider? OriginalServiceProvider { get; set; }

    private IServiceProvider? ScopedServiceProvider { get; set; }

    private AsyncServiceScope? DefaultAsyncScope { get; set; }

    private IConfigurationRoot? Configuration { get; set; }

    public ValueTask DisposeAsync()
    {
        DefaultAsyncScope?.DisposeAsync();
        _vsCodeDebugging?.DisposeAsync();
        return ValueTask.CompletedTask;
    }

    public IServiceProvider GetOriginalServiceProvider()
    {
        return OriginalServiceProvider ??
               throw new ArgumentNullException(
                   nameof(OriginalServiceProvider));
    }

    public IServiceProvider GetScopedServiceProvider()
    {
        return ScopedServiceProvider ?? throw new ArgumentNullException(nameof(ScopedServiceProvider));
    }

    public AsyncServiceScope GetDefaultAsyncScope()
    {
        return DefaultAsyncScope ?? throw new ArgumentNullException(nameof(DefaultAsyncScope));
    }

    public IConfiguration GetConfiguration()
    {
        return Configuration ?? throw new ArgumentNullException(nameof(Configuration));
    }

    public async Task ExecuteTimeBoxedAndAssertAsync<T>(
        string timeBox,
        Func<IServiceProvider, IConfigurationRoot, T, Action<string>, Task> executeFunc,
        Func<IServiceProvider, IConfigurationRoot, T, Task>? assertFunc,
        IServiceProvider serviceProvider,
        VsCodeDebugging? vsCodeDebugging = null
    ) where T : WithWorkingDirectoryExecutionContext
    {
        int timeoutMs = serviceProvider.GetRequiredService<ITimeSpanTooling>().GetTotalMsConvertedToInt(timeBox, -1);
        if (timeoutMs == -1) throw new CannotParseString("timeout cannot be -1");

        Task? timeout = Task.Delay(timeoutMs);

        Task? run = RunInternalTaskAsync(
            executeFunc,
            assertFunc,
            (_, _, _) => Task.CompletedTask,
            serviceProvider,
            vsCodeDebugging
        );

        var tasks = new List<Task> { run };

        if (vsCodeDebugging?.DevDebugging == false || _vsCodeDebugging?.DevDebugging == false) tasks.Add(timeout);

        Task? firstFinishedTask = await Task.WhenAny(tasks);

        if (firstFinishedTask == run && firstFinishedTask.IsCompletedSuccessfully) return;

        if (firstFinishedTask == timeout) throw new TimeoutException($"timeout {timeBox}");

        if (firstFinishedTask.IsFaulted)
            throw new ApplicationException($"Task faulted: {firstFinishedTask.Exception?.Message}");
    }

    public async Task ExecuteTimeBoxedAndAssertAndCleanupAsync<T>(
        string timeBox,
        Func<IServiceProvider, IConfigurationRoot, T, Action<string>, Task> executeFunc,
        Func<IServiceProvider, IConfigurationRoot, T, Task>? assertFunc,
        Func<IServiceProvider, IConfigurationRoot, T, Task>? cleanupFunc,
        IServiceProvider serviceProvider,
        VsCodeDebugging? vsCodeDebugging = null
    ) where T : WithWorkingDirectoryExecutionContext
    {
        int timeoutMs = serviceProvider.GetRequiredService<ITimeSpanTooling>().GetTotalMsConvertedToInt(timeBox, -1);
        if (timeoutMs == -1) throw new CannotParseString("timeout cannot be -1");

        Task? timeout = Task.Delay(timeoutMs);

        Task? run = RunInternalTaskAsync(
            executeFunc,
            assertFunc,
            cleanupFunc,
            serviceProvider,
            vsCodeDebugging
        );

        var tasks = new List<Task> { run };

        if (vsCodeDebugging?.DevDebugging == false || _vsCodeDebugging?.DevDebugging == false) tasks.Add(timeout);

        Task? firstFinishedTask = await Task.WhenAny(tasks);

        if (firstFinishedTask == timeout) throw new TimeoutException($"timeout {timeBox}");
    }

    public async Task RunAsync<T>(
        Func<IServiceProvider, IConfigurationRoot, T, Action<string>, Task> executeFunc,
        IServiceProvider serviceProvider,
        VsCodeDebugging? vsCodeDebugging = null
    ) where T : WithWorkingDirectoryExecutionContext
    {
        await RunInternalTaskAsync(
            executeFunc,
            (_, _, _) => Task.CompletedTask,
            (_, _, _) => Task.CompletedTask,
            serviceProvider,
            vsCodeDebugging ?? new VsCodeDebugging()
        );
    }

    public async Task ExecuteAndAssertAsync<T>(
        Func<IServiceProvider, IConfigurationRoot, T, Action<string>, Task> executeFunc,
        Func<IServiceProvider, IConfigurationRoot, T, Task>? assertFunc,
        IServiceProvider serviceProvider,
        VsCodeDebugging? vsCodeDebugging = null
    ) where T : WithWorkingDirectoryExecutionContext
    {
        await RunInternalTaskAsync(
            executeFunc,
            assertFunc,
            (_, _, _) => Task.CompletedTask,
            serviceProvider,
            vsCodeDebugging ?? new VsCodeDebugging()
        );
    }

    public async Task ExecuteAndAssertAndCleanupAsync<T>(
        Func<IServiceProvider, IConfigurationRoot, T, Action<string>, Task> executeFunc,
        Func<IServiceProvider, IConfigurationRoot, T, Task>? assertFunc,
        Func<IServiceProvider, IConfigurationRoot, T, Task>? cleanupFunc,
        IServiceProvider serviceProvider,
        VsCodeDebugging? vsCodeDebugging = null
    ) where T : WithWorkingDirectoryExecutionContext
    {
        await RunInternalTaskAsync(
            executeFunc,
            assertFunc,
            cleanupFunc,
            serviceProvider,
            vsCodeDebugging ?? _vsCodeDebugging
        );
    }

    private async Task RunInternalTaskAsync<T>(
        Func<IServiceProvider, IConfigurationRoot, T, Action<string>, Task> executeFunc,
        Func<IServiceProvider, IConfigurationRoot, T, Task>? assertFunc,
        Func<IServiceProvider, IConfigurationRoot, T, Task>? cleanupFunc,
        IServiceProvider serviceProvider,
        VsCodeDebugging? vsCodeDebugging = null
    ) where T : WithWorkingDirectoryExecutionContext
    {
        BuildIfNecessary();

        if (executeFunc is null) throw new ArgumentNullException(nameof(executeFunc));

        if (_vsCodeDebugging is null && vsCodeDebugging is not null) _vsCodeDebugging = vsCodeDebugging;

        Action<string> openVsCodeDebugging = workingDirectory =>
        {
            if (_vsCodeDebugging is null)
                return;

            if (_vsCodeDebugging?.VsProcess is not null)
                return;

            bool isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

            _vsCodeDebugging!.VsProcess = Process.Start(new ProcessStartInfo
            {
                Arguments = "-n " + workingDirectory,
                WorkingDirectory = workingDirectory,
                FileName = "code",
                UseShellExecute = true,
                CreateNoWindow = true
            });
        };

        var executionContextObject = serviceProvider.GetRequiredService<T>();

        if (_vsCodeDebugging?.Open == true && _vsCodeDebugging.OpenAuto)
            openVsCodeDebugging.Invoke(executionContextObject.WorkingDirectory!);

        Exception? thrownException = null;

        try
        {
            await executeFunc.Invoke(
                serviceProvider,
                Configuration!,
                executionContextObject,
                openVsCodeDebugging
            );

            if (assertFunc is not null)
                await assertFunc.Invoke(serviceProvider,
                    Configuration!,
                    ScopedServiceProvider!.GetRequiredService<T>());
        }
        catch (Exception e)
        {
            thrownException = e;
        }
        finally
        {
            cleanupFunc?.Invoke(serviceProvider, Configuration!, ScopedServiceProvider!.GetRequiredService<T>());
        }

        if (_vsCodeDebugging?.Keep == false)
            _vsCodeDebugging?.Stop();

        if (thrownException is not null)
        {
            ExceptionDispatchInfo? capture = ExceptionDispatchInfo.Capture(thrownException);
            capture.Throw();
        }
    }

    public void BuildIfNecessary()
    {
        if (_alreadyBuild) return;

        if (null == _configureConfigurationFunc)
            throw new ArgumentNullException(nameof(_configureConfigurationFunc));

        if (null == _configureServicesFunc)
            throw new ArgumentNullException(nameof(_configureServicesFunc));

        if (null == _configureMocksFunc)
            throw new ArgumentNullException(nameof(_configureMocksFunc));

        var configurationBuilder = new ConfigurationBuilder();

        _configureConfigurationFunc.Invoke(configurationBuilder);

        IConfigurationRoot? configuration = configurationBuilder.Build();

        var services = new ServiceCollection();

        services.AddSingleton(configuration);

        _configureServicesFunc?.Invoke(services, configuration);
        _configureMocksFunc?.Invoke(services, configuration);

        OriginalServiceProvider = services.BuildServiceProvider(new ServiceProviderOptions
            { ValidateScopes = true, ValidateOnBuild = true });

        DefaultAsyncScope = OriginalServiceProvider.CreateAsyncScope();
        ScopedServiceProvider = GetDefaultAsyncScope().ServiceProvider;
        Configuration = configuration;

        _alreadyBuild = true;
    }

    public class VsCodeDebugging : IDisposable, IAsyncDisposable
    {
        public bool Open { get; init; }
        public string? Path { get; set; }
        public string? Bin { get; init; } = "code";
        public bool? TellMe { get; set; } = false;
        public bool? Keep { get; init; } = true;

        public Process? VsProcess { get; set; }
        public bool DevDebugging { get; init; } = false;
        public bool OpenAuto { get; set; }

        public async ValueTask DisposeAsync()
        {
            await Task.Run(Dispose);
        }

        public void Dispose()
        {
            Stop();
            VsProcess?.Dispose();
        }

        public bool? Start()
        {
            return VsProcess?.Start();
        }

        public void Stop()
        {
            VsProcess?.Kill(true);
        }
    }
}