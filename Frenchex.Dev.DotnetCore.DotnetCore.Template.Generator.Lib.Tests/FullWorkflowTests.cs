using Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain;
using Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain.Abstractions;
using Frenchex.Dev.DotnetCore.DotnetCore.Testing.Lib;
using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Tests;

public class FullWorkflowTests : AbstractFullWorkflowTester
{
    public static IEnumerable<object[]> Data()
    {
        var templateGuid = Guid.NewGuid();
        yield return new object[]
                     {
                         "test case 1", new Payload
                                        {
                                            ProjectTemplateDefinition = new ProjectTemplateDefinition
                                                                        {
                                                                            Symbols = new List<ISymbolDefinition>
                                                                                      {
                                                                                          new SymbolDefinition
                                                                                          {
                                                                                              Name      = "licensing"
                                                                                            , ShortName = "l"
                                                                                            , LongName  = "licensing"
                                                                                            , DefaultValue
                                                                                                  = "// LICENSE : Read LICENSE.md"
                                                                                            , Replaces = "(licensing)"
                                                                                            , Type     = "parameter"
                                                                                          }
                                                                                      }
                                                                          , Author = "St�phane Erard"
                                                                          , Classifications = new List<string>
                                                                                              {
                                                                                                  "Frenchex"
                                                                                                , "DDD"
                                                                                              }
                                                                          , CsProj = new CsProj
                                                                                     {
                                                                                         EnforceCodeStyleInBuild = true
                                                                                       , ImplicitUsings          = true
                                                                                       , PackageLicenseFile
                                                                                             = "LICENSE.md"
                                                                                       , GenerateDocumentationFile
                                                                                             = true
                                                                                       , Nullable = true
                                                                                       , GeneratePackageOnBuild = true
                                                                                       , IncludeSymbols = true
                                                                                       , TargetFramework = "net8.0"
                                                                                       , Sdk = "Microsoft.NET.Sdk"
                                                                                     }
                                                                          , Identity  = $"_fex:test_{templateGuid}"
                                                                          , ShortName = $"_fex:test_{templateGuid}"
                                                                          , License = new License
                                                                                      {
                                                                                          Content
                                                                                              = "Copyright St�phane Erard, for education purpose only"
                                                                                      }
                                                                          , Readme = new Readme
                                                                                     {
                                                                                         Content
                                                                                             = "# This is a readme\r\n## How to test"
                                                                                     }
                                                                          , Name
                                                                                = $"Frenchex.Dev.DotnetCore.DotnetCore.Test_{templateGuid}"
                                                                          , Packages = new List<IPackageReference>
                                                                                       {
                                                                                           new PackageReference
                                                                                           {
                                                                                               Name
                                                                                                   = "Microsoft.Extensions.DependencyInjection"
                                                                                             , Version = "7.0.0"
                                                                                           }
                                                                                       }
                                                                          , Tags = new Dictionary<string, string>
                                                                                   {
                                                                                       { "language", "C#" }
                                                                                     , { "type", "project" }
                                                                                   }
                                                                        }
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
        var templateGenerator = scope.ServiceProvider.GetRequiredService<ITemplateGenerator>();


        var generationContext = new GenerationContext
                                {
                                    Path = Path.Join(Path.GetTempPath(), Path.GetRandomFileName())
                                };

        var generationResult
            = await templateGenerator.GenerateAsync(payload.ProjectTemplateDefinition, generationContext, ct);

        Assert.IsNotNull(generationResult);

        var csProjPath = new CsProjPath
                         {
                             Path = $"{generationContext.Path}\\{payload.ProjectTemplateDefinition.Name}.csproj"
                         };

        var codeWriter          = scope.ServiceProvider.GetRequiredService<IGeneratedCodeWriter>();
        var templateInstaller   = scope.ServiceProvider.GetRequiredService<ITemplateInstaller>();
        var packagesInstaller   = scope.ServiceProvider.GetRequiredService<IPackagesInstaller>();
        var templateUninstaller = scope.ServiceProvider.GetRequiredService<ITemplateUnInstaller>();

        await codeWriter.WriteAsync(generationResult.Generation, ct);
        await packagesInstaller.InstallAsync(csProjPath, payload.ProjectTemplateDefinition.Packages, ct);
        await templateInstaller.InstallAsync(csProjPath, ct);
        await templateUninstaller.UnInstallAsync(csProjPath, ct);

        await OpenVsCodeAsync(generationContext.Path, cancellationToken: ct);
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
    public required ProjectTemplateDefinition ProjectTemplateDefinition { get; set; }
}