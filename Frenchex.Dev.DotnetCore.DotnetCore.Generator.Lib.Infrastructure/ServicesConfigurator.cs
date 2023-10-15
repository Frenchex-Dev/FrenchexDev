﻿#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Infrastructure;

public static class ServicesConfigurator
{
    public static void Configure(
        IServiceCollection services
    )
    {
        CodeGeneration.Lib.ServicesConfigurator.Configure(services);
        Project.AddPackage.Lib.ServicesConfigurator.Configure(services);
        Project.AddProjectReference.Lib.ServicesConfigurator.Configure(services);
        Solution.Generator.Lib.ServicesConfigurator.Configure(services);
        Solution.AddProject.Lib.ServicesConfigurator.Configure(services);
        Project.Generator.Lib.ServicesConfigurator.Configure(services);
        Template.Generator.Lib.ServicesConfigurator.Configure(services);
    }
}
