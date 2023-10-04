#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using System.Diagnostics;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Frenchex.Dev.DotnetCore.Testing.Lib;

public abstract class AbstractFullWorkflowTester
{
    public async Task<ServiceProvider> BuildServiceProviderAsync(
        CancellationToken cancellationToken = default
    )
    {
        var serviceCollection = new ServiceCollection();
        await ConfigureServicesAsync(serviceCollection, cancellationToken);
        return serviceCollection.BuildServiceProvider(new ServiceProviderOptions
                                                      {
                                                          ValidateOnBuild = true
                                                        , ValidateScopes  = true
                                                      });
    }

    protected abstract Task ConfigureServicesAsync(
        IServiceCollection services
      , CancellationToken  cancellationToken = default
    );

    public async Task RunScopedAsync(
        ServiceProvider                                  services
      , Func<AsyncServiceScope, CancellationToken, Task> bizFunc
      , CancellationToken                                cancellationToken = default
    )
    {
        await using var scope = services.CreateAsyncScope();
        await bizFunc(scope, cancellationToken);
    }


    public async Task<T> RunScopedAsync<T>(
        ServiceProvider                                     services
      , Func<AsyncServiceScope, CancellationToken, Task<T>> bizFunc
      , CancellationToken                                   cancellationToken = default
    )
    {
        await using var scope = services.CreateAsyncScope();
        var             r     = await bizFunc(scope, cancellationToken);
        return r;
    }

    protected static async Task OpenVsCodeAsync(
        string            path
      , string            vsCodePath        = "C:\\Program Files\\Microsoft VS Code\\Code.exe"
      , CancellationToken cancellationToken = default
    )
    {
        var codeProcess = new Process
                          {
                              StartInfo = new ProcessStartInfo
                                          {
                                              FileName = vsCodePath
                                            , ArgumentList =
                                              {
                                                  path
                                                , "-n"
                                              }
                                            , RedirectStandardInput  = true
                                            , RedirectStandardOutput = true
                                            , RedirectStandardError  = true
                                            , CreateNoWindow         = false
                                          }
                          };

        codeProcess.Start();
        await codeProcess.WaitForExitAsync(cancellationToken);
    }
}
