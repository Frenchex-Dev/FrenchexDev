using Microsoft.AspNetCore.TestHost;

namespace Frenchex.Dev.Vos.Web.Api.Server.Tests
{
    [TestClass]
    public class ApiServerTests
    {
        [TestMethod]
        public async Task CanStartAndStop()
        {
            WebApplicationBuilder webAppBuilder = WebApplication.CreateBuilder(Array.Empty<string>());
            webAppBuilder.Configure();

            var testServer = new TestServer(webAppBuilder.Services)
        }
    }
}
