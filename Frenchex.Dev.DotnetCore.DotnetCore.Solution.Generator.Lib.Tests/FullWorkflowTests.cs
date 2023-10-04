#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.DotnetCore.DotnetCore.Solution.Generator.Lib.Domain.Abstractions;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Solution.Generator.Lib.Tests;

public class FullWorkflowTests : AbstractFullWorkflowTester
{
    public static IEnumerable<object[]> Data()
    {
        yield return new object[]
                     {
                         "test case 1", new Payload
                                        {
                                            Name = "Foo"
                                        }
                     };
    }

    [Test] [TestCaseSource(nameof(Data))] public async Task FullWorkflow(
        string  testCaseName
      , Payload payload
    )
    {
        var services = await BuildServiceProviderAsync();

        await RunScopedAsync(services, async (
                                           scope
                                         , ct
                                       ) =>
                                       {
                                           await RunInternalAsync(scope, payload, ct);
                                       });
    }

    private static async Task RunInternalAsync(
        AsyncServiceScope scope
      , Payload           payload
      , CancellationToken ct
    )
    {
        var solutionDefinition = new SolutionDefinition
                                 {
                                     Path = Path.Join(Path.GetTempPath(), Path.GetRandomFileName())
                                   , Name = payload.Name
                                 };

        var solutionGenerator = scope.ServiceProvider.GetRequiredService<ISolutionGenerator>();

        var solutionGenerationResult = await solutionGenerator.GenerateAsync(solutionDefinition, ct);

        solutionGenerationResult.ShouldBeAssignableTo<SolutionGeneratedResult>();
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
    public required string Name { get; set; }
}
