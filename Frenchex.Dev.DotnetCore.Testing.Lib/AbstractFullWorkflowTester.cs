#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using System.Diagnostics;
using System.Runtime.ExceptionServices;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Frenchex.Dev.DotnetCore.Testing.Lib
{
    public abstract class AbstractFullWorkflowTester
    {
        public async Task<ServiceProvider> BuildServiceProviderAsync(
            CancellationToken cancellationToken = default
        )
        {
            return await TryCatchAsync<ServiceProvider, Exception>(
                                                                   async () =>
                                                                   {
                                                                       var serviceCollection = new ServiceCollection();
                                                                       await ConfigureServicesAsync(
                                                                                                    serviceCollection
                                                                                                  , cancellationToken);
                                                                       return serviceCollection.BuildServiceProvider(
                                                                                                                     new
                                                                                                                     ServiceProviderOptions
                                                                                                                     {
                                                                                                                         ValidateOnBuild
                                                                                                                             = true
                                                                                                                       , ValidateScopes
                                                                                                                             = true
                                                                                                                     });
                                                                   });
        }

        protected static async Task TryCatchAsync<TException>(
            Func<Task>              function
          , Func<TException, Task>? catcher = null
        ) where TException : Exception
        {
            try
            {
                await function();
            }
            catch (TException ex)
            {
                if (catcher != null)
                {
                    await catcher(ex);
                }

                ExceptionDispatchInfo.Capture(ex)
                                     .Throw();
                throw;
            }
        }

        protected static async Task<TReturn> TryCatchAsync<TReturn, TException>(
            Func<Task<TReturn>>     function
          , Func<TException, Task>? catcher = null
        ) where TException : Exception
        {
            try
            {
                var result = await function();
                return result;
            }
            catch (TException ex)
            {
                if (catcher != null)
                {
                    await catcher(ex);
                }

                ExceptionDispatchInfo.Capture(ex)
                                     .Throw();
                throw;
            }
        }

        protected abstract Task ConfigureServicesAsync(
            IServiceCollection services
          , CancellationToken  cancellationToken = default
        );

        public static async Task RunScopedAsync(
            ServiceProvider                                  services
          , Func<AsyncServiceScope, CancellationToken, Task> function
          , CancellationToken                                cancellationToken = default
        )
        {
            await using var scope = services.CreateAsyncScope();
            await function(scope, cancellationToken);
        }


        public static async Task<T> RunScopedAsync<T>(
            ServiceProvider                                     services
          , Func<AsyncServiceScope, CancellationToken, Task<T>> function
          , CancellationToken                                   cancellationToken = default
        )
        {
            await using var scope = services.CreateAsyncScope();
            var             r     = await function(scope, cancellationToken);
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
}
