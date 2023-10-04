#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.DotnetCore.Process.Lib.Domain;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Frenchex.Dev.DotnetCore.Process.Lib.Infrastructure;

public class ProcessStarterFactory(
    IServiceProvider serviceProvider
) : IProcessStarterFactory
{
    public IProcessStarter Factory()
    {
        return serviceProvider.GetRequiredService<IProcessStarter>();
    }
}
