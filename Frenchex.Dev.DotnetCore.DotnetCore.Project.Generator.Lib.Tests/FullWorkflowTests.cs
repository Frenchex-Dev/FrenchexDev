using Frenchex.Dev.DotnetCore.DotnetCore.Project.Generator.Lib.Domain.Abstractions;
using Frenchex.Dev.DotnetCore.Testing.Lib;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;

namespace Frenchex.Dev.DotnetCore.DotnetCore.Project.Generator.Lib.Tests;

public class FullWorkflowTests : AbstractFullWorkflowTester
{
    public static IEnumerable<object[]> Data()
    {
        yield return new object[]
                     {
                         "test case 1", new Payload()
                                        {
                                            ProjectDefinition = new ProjectDefinition()
                                                               {
                                                                   TemplateName = "lib",
                                                                   Language = "C#",
                                                                   Name = "MyProject",
                                                                   ExtraArgs = new Dictionary<string, string>(),
                                                                   ProjectsReferences = new List<IProjectReference>(){}
                                                               }
                                        }
                     };
    }

    [Test]
    [TestCaseSource(nameof(Data))]
    public async Task FullWorkflow(string testCaseName, Payload payload)
    {
        var services = await BuildServiceProviderAsync();

        await RunScopedAsync(services, async (
                                           scope
                                         , token
                                       ) =>
                                       {
                                           await RunInternalAsync(scope, payload, token);
                                       });
    }

    private async Task RunInternalAsync(
        AsyncServiceScope scope
      , Payload           payload
      , CancellationToken token
    )
    {
        var projectGenerator = scope.ServiceProvider.GetRequiredService<IProjectGenerator>();

        var generationContext = new GenerationContext()
                                {
                                    Path = Path.Join(Path.GetTempPath(), Path.GetRandomFileName())
                                };

        var response = await projectGenerator.GenerateAsync(payload.ProjectDefinition, generationContext, token);

        response.ShouldBeAssignableTo<ProjectGenerationOk>();
    }

    protected override Task ConfigureServicesAsync(
        IServiceCollection services
      , CancellationToken  cancellationToken = default
    )
    {
        ServicesConfigurator.Configure(services);
        return Task.CompletedTask;
    }
}

public class Payload
{
    public required ProjectDefinition ProjectDefinition { get; set; }
}