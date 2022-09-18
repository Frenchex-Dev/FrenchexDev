using System.Diagnostics;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.Dotnet.Core.UnitTesting.Lib.Domain;

public class UnitTest : IAsyncDisposable
{
    private readonly Action<IConfigurationBuilder> _configureConfigurationFunc;
    private readonly Action<IServiceCollection, IConfigurationRoot>? _configureMocksFunc;
    private readonly Action<IServiceCollection, IConfigurationRoot>? _configureServicesFunc;
    private bool _alreadyBuild;
    private Process? _process;

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

    public IServiceProvider? ServiceProvider { get; protected set; }
    public AsyncServiceScope? AsyncScope { get; protected set; }
    public IConfigurationRoot? Configuration { get; protected set; }

    public ValueTask DisposeAsync()
    {
        AsyncScope?.DisposeAsync();

        return ValueTask.CompletedTask;
    }

    public async Task RunAsync<T>(
        Func<IServiceProvider, IConfigurationRoot, T, Action<string>, Task> executeFunc,
        Func<IServiceProvider, IConfigurationRoot, T, Task>? assertFunc = null,
        Func<IServiceProvider, IConfigurationRoot, T, Task>? cleanupFunc = null,
        VsCodeDebugging? vsCodeDebugging = null
    ) where T : WithWorkingDirectoryExecutionContext
    {
        await RunInternalTaskAsync(
            executeFunc,
            assertFunc,
            cleanupFunc,
            vsCodeDebugging
        );
    }

    private async Task RunInternalTaskAsync<T>(
        Func<IServiceProvider, IConfigurationRoot, T, Action<string>, Task> executeFunc,
        Func<IServiceProvider, IConfigurationRoot, T, Task>? assertFunc,
        Func<IServiceProvider, IConfigurationRoot, T, Task>? cleanupFunc,
        VsCodeDebugging? vsCodeDebugging
    ) where T : WithWorkingDirectoryExecutionContext
    {
        BuildIfNecessary();

        if (executeFunc == null)
        {
            throw new ArgumentNullException(nameof(executeFunc));
        }

        _process = null;

        Action<string> openVsCodeDebugging = (string workingDirectory) =>
        {
            var isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

            _process = Process.Start(
                vsCodeDebugging?.Bin ?? (isWindows ? "C:\\Program Files\\Microsoft VS Code\\Code.exe" : "code"),
                "-n " + workingDirectory);
        };

        Action killVsCodeDebugging = () =>
        {
            _process?.Kill();
        };

        var executionContextObject = ServiceProvider!.GetRequiredService<T>();

        if (vsCodeDebugging?.Open == true)
        {
            openVsCodeDebugging.Invoke(executionContextObject.WorkingDirectory!);
        }

        Exception? thrownException = null;

        try
        {
            await executeFunc.Invoke(ServiceProvider!,
                Configuration!,
                executionContextObject,
                openVsCodeDebugging);

            if (assertFunc is not null)
            {
                await assertFunc.Invoke(ServiceProvider!, Configuration!, ServiceProvider!.GetRequiredService<T>());
            }
        }
        catch (Exception e)
        {
            thrownException = e;
        }
        finally
        {
            cleanupFunc?.Invoke(ServiceProvider!, Configuration!, ServiceProvider!.GetRequiredService<T>());
        }

        if (vsCodeDebugging?.Keep == false)
            _process?.Kill();

        if (thrownException is not null)
        {
            var capture = ExceptionDispatchInfo.Capture(thrownException);
            capture?.Throw();
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

        _configureConfigurationFunc?.Invoke(configurationBuilder);

        var configuration = configurationBuilder.Build();

        var services = new ServiceCollection();

        services.AddSingleton(configuration);

        _configureServicesFunc?.Invoke(services, configuration);
        _configureMocksFunc?.Invoke(services, configuration);

        var di = services.BuildServiceProvider();
        AsyncScope = di.CreateAsyncScope();
        ServiceProvider = AsyncScope.Value.ServiceProvider;
        Configuration = configuration;

        _alreadyBuild = true;
    }

    public class VsCodeDebugging : IDisposable, IAsyncDisposable
    {
        public bool Open { get; set; }
        public string? Path { get; set; }
        public string? Bin { get; set; }
        public bool? TellMe { get; set; }
        public bool? Keep { get; set; }

        public Process? VsProcess { get; set; }

        public bool? Start()
        {
            return VsProcess?.Start();
        }

        public void Stop()
        {
            VsProcess?.Kill(true);
        }

        public void Dispose()
        {
            VsProcess?.Dispose();
        }

        public async ValueTask DisposeAsync()
        {
            await Task.Run(() => { VsProcess?.Dispose(); });
        }
    }
}