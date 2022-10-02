using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Actions.Configuration.Load;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Actions.Configuration.Save;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Actions.Naming;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Actions.Networking;
using Frenchex.Dev.Vos.Lib.Domain.Actions.Configuration.Load;
using Frenchex.Dev.Vos.Lib.Domain.Actions.Configuration.Save;
using Frenchex.Dev.Vos.Lib.Domain.Actions.Naming;
using Frenchex.Dev.Vos.Lib.Domain.Actions.Networking;
using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.Vos.Lib.Domain.Actions.DependencyInjection;

public static class ServicesConfiguration
{
    public static IServiceCollection ConfigureServices(IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddScoped<IConfigurationLoadAction, ConfigurationLoadAction>()
            .AddScoped<IConfigurationSaveAction, ConfigurationSaveAction>()
            .AddScoped<IDefaultGatewayGetterAction, DefaultGatewayGetterAction>()
            .AddScoped<IVexNameToVagrantNameConverter, VexNameToVagrantNameConverter>()
            ;
        return serviceCollection;
    }
}