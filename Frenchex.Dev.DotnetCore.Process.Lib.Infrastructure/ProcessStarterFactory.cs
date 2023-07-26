#region Usings

using Frenchex.Dev.DotnetCore.Process.Lib.Domain;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Frenchex.Dev.DotnetCore.Process.Lib.Infrastructure;

public class ProcessStarterFactory : IProcessStarterFactory
{
    private readonly IServiceProvider _serviceProvider;

    public ProcessStarterFactory(
        IServiceProvider serviceProvider
    )
    {
        _serviceProvider = serviceProvider;
    }

    public IProcessStarter Factory()
    {
        return _serviceProvider.GetRequiredService<IProcessStarter>();
    }
}
