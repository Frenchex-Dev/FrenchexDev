using System.Diagnostics;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using Frenchex.Dev.Dotnet.Core.Tooling.TimeSpan.Lib;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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

    public IServiceProvider GetOriginalServiceProvider() => OriginalServiceProvider ??
                                                            throw new ArgumentNullException(
                                                                nameof(OriginalServiceProvider));

    private IServiceProvider? ScopedServiceProvider { get; set; }

    public IServiceProvider GetScopedServiceProvider() =>
        ScopedServiceProvider ?? throw new ArgumentNullException(nameof(ScopedServiceProvider));

    private AsyncServiceScope? DefaultAsyncScope { get; set; }

    public AsyncServiceScope GetDefaultAsyncScope() =>
        DefaultAsyncScope ?? throw new ArgumentNullException(nameof(DefaultAsyncScope));

    private IConfigurationRoot? Configuration { get; set; }
    public IConfiguration GetConfiguration() => Configuration ?? throw new ArgumentNullException(nameof(Configuration));

    public ValueTask DisposeAsync()
    {
        DefaultAsyncScope?.DisposeAsync();
        _vsCodeDebugging?.DisposeAsync();
        return ValueTask.CompletedTask;
    }

    public async Task ExecuteTimeBoxedAndAssertAsync<T>(
        string timeBox,
        Func<IServiceProvider, IConfigurationRoot, T, Action<string>, Task> executeFunc,
        Func<IServiceProvider, IConfigurationRoot, T, Task>? assertFunc,
        IServiceProvider serviceProvider,
        VsCodeDebugging? vsCodeDebugging = null
    ) where T : WithWorkingDirectoryExecutionContext
    {
        var timeoutMs = serviceProvider.GetRequiredService<ITimeSpanTooling>().GetTotalMsConvertedToInt(timeBox, -1);
        if (timeoutMs == -1)
        {
            throw new CannotParseString("timeout cannot be -1");
        }

        var timeout = Task.Delay(timeoutMs);

        var run = RunInternalTaskAsync(
            executeFunc,
            assertFunc,
            (_, _, _) => Task.CompletedTask,
            serviceProvider,
            vsCodeDebugging
        );

        var tasks = new List<Task> {run};

        if (vsCodeDebugging?.DevDebugging == false || _vsCodeDebugging?.DevDebugging == false)
        {
            tasks.Add(timeout);
        }

        var firstFinishedTask = await Task.WhenAny(tasks);

        if (firstFinishedTask == run && firstFinishedTask.IsCompletedSuccessfully)
        {
            return;
        }

        if (firstFinishedTask == timeout)
        {
            throw new TimeoutException($"timeout {timeBox}");
        }

        if (firstFinishedTask.IsFaulted)
        {
            throw new ApplicationException($"Task faulted: {firstFinishedTask.Exception?.Message}");
        }
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
        var timeoutMs = serviceProvider.GetRequiredService<ITimeSpanTooling>().GetTotalMsConvertedToInt(timeBox, -1);
        if (timeoutMs == -1)
        {
            throw new CannotParseString("timeout cannot be -1");
        }

        var timeout = Task.Delay(timeoutMs);

        var run = RunInternalTaskAsync(
            executeFunc,
            assertFunc,
            cleanupFunc,
            serviceProvider,
            vsCodeDebugging
        );

        List<Task> tasks = new List<Task> {run};

        if (vsCodeDebugging?.DevDebugging == false || _vsCodeDebugging?.DevDebugging == false)
        {
            tasks.Add(timeout);
        }

        var firstFinishedTask = await Task.WhenAny(tasks);

        if (firstFinishedTask == timeout)
        {
            throw new TimeoutException($"timeout {timeBox}");
        }
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

        if (executeFunc is null)
        {
            throw new ArgumentNullException(nameof(executeFunc));
        }

        if (_vsCodeDebugging is null && vsCodeDebugging is not null)
        {
            _vsCodeDebugging = vsCodeDebugging;
        }

        Action<string> openVsCodeDebugging = (workingDirectory) =>
        {
            if (_vsCodeDebugging is null)
                return;

            if (_vsCodeDebugging?.VsProcess is not null)
                return;

            var isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

            _vsCodeDebugging!.VsProcess = Process.Start(
                _vsCodeDebugging?.Bin ?? (isWindows ? "C:\\Program Files\\Microsoft VS Code\\Code.exe" : "code"),
                "-n " + workingDirectory);
        };

        var executionContextObject = serviceProvider.GetRequiredService<T>();

        if (_vsCodeDebugging?.Open == true)
        {
            openVsCodeDebugging.Invoke(executionContextObject.WorkingDirectory!);
        }

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
            {
                await assertFunc.Invoke(serviceProvider,
                    Configuration!,
                    ScopedServiceProvider!.GetRequiredService<T>());
            }
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
            var capture = ExceptionDispatchInfo.Capture(thrownException);
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

        var configuration = configurationBuilder.Build();

        var services = new ServiceCollection();

        services.AddSingleton(configuration);

        _configureServicesFunc?.Invoke(services, configuration);
        _configureMocksFunc?.Invoke(services, configuration);

        OriginalServiceProvider = services.BuildServiceProvider(new ServiceProviderOptions()
            {ValidateScopes = true, ValidateOnBuild = true});

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