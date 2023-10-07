#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain;
using Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Abstractions;
using Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Abstractions.Project;
using Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Abstractions.Solution;
using Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Abstractions.Solution.Global;
using Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Abstractions.Template;
using Frenchex.Dev.DotnetCore.Testing.Lib;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Tests;

public class FullWorkflowTests : AbstractFullWorkflowTester
{
    protected static IEnumerable<object[]> Data()
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
                                                                                                , Gobal = new Global
                                                                                                          {
                                                                                                              Sdk = new Sdk
                                                                                                                    {
                                                                                                                        Version
                                                                                                                            = "7.0.400"
                                                                                                                      , RollForward
                                                                                                                            = "latestPatch"
                                                                                                                    }
                                                                                                          }
                                                                                              }
                                                                       , ProjectsDefinitions = new List<IProjectDefinition>
                                                                                               {
                                                                                                   new ProjectDefintion
                                                                                                   {
                                                                                                       CsProj = new CsProj
                                                                                                                {
                                                                                                                    Name = "Foo.Lib"
                                                                                                                  , SolutionFolder
                                                                                                                        = "Foo"
                                                                                                                }
                                                                                                     , ExternalProjectsReferences
                                                                                                           = new List<
                                                                                                               IExternalProjectReference>()
                                                                                                     , PackagesReferences
                                                                                                           = new List<
                                                                                                               IPackageReference>()
                                                                                                     , ProjectsReferences
                                                                                                           = new List<
                                                                                                               IProjectReference>()
                                                                                                     , Template = "classlib"
                                                                                                     , TemplateArgs
                                                                                                           = new Dictionary<string,
                                                                                                               string>()
                                                                                                   }
                                                                                               }
                                                                       , TemplatesDefinitions = new List<ITemplateDefinition>
                                                                                                {
                                                                                                    new TemplateDefinition
                                                                                                    {
                                                                                                        Name
                                                                                                            = $"Foo.Lib.Template_{Guid.NewGuid()}"
                                                                                                      , Args
                                                                                                            = new List<
                                                                                                                  ITemplateArgumentDefinition>
                                                                                                              {
                                                                                                                  new
                                                                                                                  TemplateArgumentDefinition
                                                                                                                  {
                                                                                                                      Name = "licencing"
                                                                                                                    , DefaultValue
                                                                                                                          = "// Please read LICENSE.md"
                                                                                                                    , Replace
                                                                                                                          = "(licensing)"
                                                                                                                    , Type = "parameter"
                                                                                                                  }
                                                                                                              }
                                                                                                    }
                                                                                                }
                                                                     }
                                        }
                     };
    }

    [Test] [TestCaseSource(nameof(Data))] public async Task FullWorkflowTest(
        string  testCaseName
      , Payload payload
    )
    {
        var services = await BuildServiceProviderAsync();

        await RunScopedAsync(
                             services
                           , async (
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

    private static async Task RunInternalAsync(
        string            _
      , Payload           payload
      , AsyncServiceScope scope
      , CancellationToken token
    )
    {
        var service = scope.ServiceProvider.GetRequiredService<IMetaSolutionDefinitionGenerator>();

        var generationContext = new MetaSolutionGenerationContext
                                {
                                    Path = Path.Join(Path.GetTempPath(), Path.GetRandomFileName())
                                };

        var response = await service.GenerateAsync(payload.MetaSolutionDefinition, generationContext, token);

        await OpenVsCodeAsync(generationContext.Path, cancellationToken: token);

        response.ShouldBeAssignableTo<MetaSolutionDefinitionGenerationResult>();

        response.SolutionGenerationResult.ShouldBeAssignableTo<SolutionGenerationOkResult>();

        response
            .TemplatesGenerationsResults
            .ToList()
            .ForEach(x => x.ShouldBeAssignableTo<TemplateGenerationOkResult>());

        response
            .ProjectsGenerationsResults
            .ToList()
            .ForEach(x => x.ShouldBeAssignableTo<ProjectGenerationOkResult>());
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
    public required IMetaSolutionDefinition MetaSolutionDefinition { get; set; }
}
