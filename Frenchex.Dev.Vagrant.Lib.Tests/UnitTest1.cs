using FluentAssertions;
using Frenchex.Dev.DotnetCore.Process.Lib;
using Frenchex.Dev.DotnetCore.Process.Lib.Domain;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Init;
using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.Vagrant.Lib.Tests
{
    public class Tests
    {
        [Test]
        public async Task Test1()
        {
            #region Prepare
            var servicesBuilder = new ServiceCollection();

            ServicesConfigurator.Configure(servicesBuilder);

            var services = servicesBuilder
                .BuildServiceProvider(new ServiceProviderOptions()
                {
                    ValidateOnBuild = true,
                    ValidateScopes = true
                });

            await using var scope = services.CreateAsyncScope();

            var service = scope.ServiceProvider.GetRequiredService<IVagrantInitCommand>();

            var request = new VagrantInitRequest()
            {
                Name = "alpine/317"
            };

            var context = new VagrantCommandExecutionContext()
            {
                WorkingDirectory = Path.Join(Path.GetTempPath(), Path.GetRandomFileName()),
            };

            var listeners =
                new VagrantCommandExecutionListeners(new List<Func<string, Task>>(), new List<Func<string, Task>>());

            List<string> errors = new List<string>();
            List<string> output = new List<string>();

            listeners.AddStdErrListener(async (line) =>
            {
                errors.Add(line);
            });

            listeners.AddStdOutListener(async (line) =>
            {
                output.Add(line);
            });
            #endregion

            #region Execute

            var response = await service.StartAsync(request, context, listeners);

            #endregion

            #region Asserts

            response.Should().BeAssignableTo<VagrantInitResponse>("We have a response");

            #endregion
        }

        internal class TestDoubleProcess : IProcessStarter
        {
            
        }
    }
}