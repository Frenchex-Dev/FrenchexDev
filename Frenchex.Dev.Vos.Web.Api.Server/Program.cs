
namespace Frenchex.Dev.Vos.Web.Api.Server;

public partial class Program
{
    public static async Task Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        builder.Configure();

        WebApplication app = builder.Build();

        app.Configure();

        await app.RunAsync();
    }
}