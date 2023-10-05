#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Abstractions;
using Frenchex.Dev.DotnetCore.DotnetCore.Project.Generator.Lib.Domain.Abstractions;
using Frenchex.Dev.DotnetCore.DotnetCore.Solution.Generator.Lib.Domain.Abstractions;
using Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain.Abstractions;
using Frenchex.Dev.DotnetCore.Testing.Lib;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using GenerationContext = Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Abstractions.GenerationContext;

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Tests;

public class FullWorkflowTests : AbstractFullWorkflowTester
{
    public static IEnumerable<object[]> Data()
    {
        yield return new object[]
                     {
                         "test case 1", new Payload
                                        {
                                            MetaSolutionDefinition = new MetaSolutionDefinition
                                                                     {
                                                                         SolutionDefinition = new SolutionDefinition
                                                                                              {
                                                                                                  Name = "Foo"
                                                                                              }
                                                                       , ProjectsDefinitions
                                                                             = new List<IProjectDefinition>
                                                                               {
                                                                                   new ProjectDefinition
                                                                                   {
                                                                                       ExtraArgs
                                                                                           = new Dictionary<string,
                                                                                                 string>
                                                                                             {
                                                                                                 {
                                                                                                     "--framework"
                                                                                                   , "net-8.0"
                                                                                                 }
                                                                                                ,
                                                                                                 {
                                                                                                     "--langVersion"
                                                                                                   , "latest"
                                                                                                 }
                                                                                             }
                                                                                     , Name = "Foo.Lib"
                                                                                     , ProjectsReferences
                                                                                           = new
                                                                                               List<IProjectReference>()
                                                                                     , TemplateName = "classlib"
                                                                                     , Language     = "C#"
                                                                                   }
                                                                               }
                                                                       , TemplatesDefinitions
                                                                             = new List<ITemplateDefinition>()
                                                                     }
                                        }
                     };
    }

    [Test] [TestCaseSource(nameof(Data))] public async Task Test1(
        string  testCaseName
      , Payload payload
    )
    {
        var services = await BuildServiceProviderAsync();

        await RunScopedAsync(services, async (
                                           scope
                                         , token
                                       ) =>
                                       {
                                           try
                                           {
                                               await RunInternalAsync(testCaseName, payload, scope, token);
                                           }
                                           catch (Exception ex)
                                           {
                                               Console.WriteLine(ex.ToString());
                                           }
                                       });
    }

    private async Task RunInternalAsync(
        string            testCaseName
      , Payload           payload
      , AsyncServiceScope scope
      , CancellationToken token
    )
    {
        var service = scope.ServiceProvider.GetRequiredService<IMetaSolutionDefinitionGenerator>();

        var generationContext = new GenerationContext
                                {
                                    Path = Path.Join(Path.GetTempPath(), Path.GetRandomFileName())
                                };

        var response = await service.GenerateAsync(payload.MetaSolutionDefinition, generationContext, token);

        await OpenVsCodeAsync(generationContext.Path, cancellationToken: token);

        response.ShouldBeAssignableTo<MetaSolutionDefinitionGenerationResult>();

        response.SolutionGenerationResult.ShouldBeAssignableTo<SolutionGenerationOkResult>();
        response.TemplatesGenerationsResults.ToList()
                .ForEach(x => x.ShouldBeAssignableTo<TemplateGenerationOkResult>());

        response.ProjectsGenerationsResults.ToList()
                .ForEach(x => x.ShouldBeAssignableTo<ProjectGenerationOk>());
    }

    protected override Task ConfigureServicesAsync(
        IServiceCollection services
      , CancellationToken  cancellationToken = default
    )
    {
        ServicesConfigurator.ConfigureServices(services);
        return Task.CompletedTask;
    }
}

public class Payload
{
    public required IMetaSolutionDefinition MetaSolutionDefinition { get; set; }
}
