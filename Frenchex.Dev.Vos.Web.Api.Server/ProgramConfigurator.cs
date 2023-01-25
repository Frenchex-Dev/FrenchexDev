#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

using Frenchex.Dev.Vos.Web.Api.Server.Controllers.Define.Machine.Add;
using Frenchex.Dev.Vos.Web.Api.Server.Controllers.Define.MachineType.Add;
using Frenchex.Dev.Vos.Web.Api.Server.Controllers.Init;

namespace Frenchex.Dev.Vos.Web.Api.Server;

public static class ProgramConfiguratorExtensions
{
    public static WebApplicationBuilder Configure(this WebApplicationBuilder webApplicationBuilder)
    {
        webApplicationBuilder.Services.AddControllers();
        webApplicationBuilder.Services.AddEndpointsApiExplorer();
        webApplicationBuilder.Services.AddSwaggerGen();

        webApplicationBuilder.Services.AddScoped<IInitRequestAsyncHandler, InitRequestAsyncHandler>();
        webApplicationBuilder.Services.AddScoped<IDefineMachineTypeAddRequestAsyncHandler, DefineMachineTypeAddRequestAsyncHandler>();
        webApplicationBuilder.Services.AddScoped<IDefineMachineAddRequestAsyncHandler, DefineMachineAddRequestAsyncHandler>();

        Lib.DependencyInjection.ServicesConfiguration.StaticConfigureServices(webApplicationBuilder.Services);

        return webApplicationBuilder;
    }

    public static WebApplication Configure(this WebApplication webApplication)
    {
        if (webApplication.Environment.IsDevelopment())
        {
            webApplication.UseSwaggerUI();
        }

        webApplication.UseSwagger();
        webApplication.UseHttpsRedirection();
        webApplication.UseAuthorization();
        webApplication.MapControllers();

        return webApplication;
    }
}