using System.Diagnostics;
using Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain;
using Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Tests;

public class FullWorkflowTests : AbstractFullWorkflowTester
{
    [Test] public async Task FullWorkflow()
    {
        var services = await BuildServiceProviderAsync();

        await RunScopedAsync(services, async (
                                           scope
                                         , ct
                                       ) =>
                                       {
                                           await RunInternalAsync(scope, ct);
                                       });
    }

    private static async Task RunInternalAsync(
        AsyncServiceScope scope
      , CancellationToken ct
    )
    {
        var templateGenerator = scope.ServiceProvider.GetRequiredService<ITemplateGenerator>();

        var templateGuid = Guid.NewGuid();

        var projectTemplateDefinition = new ProjectTemplateDefinition
                                        {
                                            Symbols = new List<ISymbolDefinition>
                                                      {
                                                          new SymbolDefinition
                                                          {
                                                              Name         = "licensing"
                                                            , ShortName    = "l"
                                                            , LongName     = "licensing"
                                                            , DefaultValue = "// LICENSE : Read LICENSE.md"
                                                            , Replaces     = "(licensing)"
                                                            , Type         = "parameter"
                                                          }
                                                      }
                                          , Author = "Stéphane Erard"
                                          , Classifications = new List<string>
                                                              {
                                                                  "Frenchex"
                                                                , "DDD"
                                                              }
                                          , CsProj = new CsProj
                                                     {
                                                         EnforceCodeStyleInBuild   = true
                                                       , ImplicitUsings            = true
                                                       , PackageLicenseFile        = "LICENSE.md"
                                                       , GenerateDocumentationFile = true
                                                       , Nullable                  = true
                                                       , GeneratePackageOnBuild    = true
                                                       , IncludeSymbols            = true
                                                       , TargetFramework           = "net8.0"
                                                       , Sdk                       = "Microsoft.NET.Sdk"
                                                     }
                                          , Identity  = $"_fex:test_{templateGuid}"
                                          , ShortName = $"_fex:test_{templateGuid}"
                                          , License = new License
                                                      {
                                                          Content
                                                              = "Copyright Stéphane Erard, for education purpose only"
                                                      }
                                          , Readme = new Readme
                                                     {
                                                         Content = "# This is a readme\r\n## How to test"
                                                     }
                                          , Name = $"Frenchex.Dev.DotnetCore.DotnetCore.Test_{templateGuid}"
                                          , Packages = new List<IPackageReference>
                                                       {
                                                           new PackageReference
                                                           {
                                                               Name    = "Microsoft.Extensions.DependencyInjection"
                                                             , Version = "7.0.0"
                                                           }
                                                       }
                                          , Tags = new Dictionary<string, string>
                                                   {
                                                       { "language", "C#" }
                                                     , { "type", "project" }
                                                   }
                                        };

        var generationContext = new GenerationContext
                                {
                                    Path = Path.Join(Path.GetTempPath(), Path.GetRandomFileName())
                                };

        var generationResult = await templateGenerator.GenerateAsync(projectTemplateDefinition, generationContext, ct);

        Assert.IsNotNull(generationResult);

        var codeWriter = scope.ServiceProvider.GetRequiredService<IGeneratedCodeWriter>();

        await codeWriter.WriteAsync(generationResult.Generation, ct);

        var packagesInstaller = scope.ServiceProvider.GetRequiredService<IPackagesInstaller>();

        var csProjPath = new CsProjPath
                         {
                             Path = $"{generationContext.Path}\\{projectTemplateDefinition.Name}.csproj"
                         };

        await packagesInstaller.InstallAsync(csProjPath, projectTemplateDefinition.Packages, ct);

        var templateInstaller = scope.ServiceProvider.GetRequiredService<ITemplateInstaller>();

        await templateInstaller.InstallAsync(csProjPath, ct);

        var templateUninstaller = scope.ServiceProvider.GetRequiredService<ITemplateUnInstaller>();

        await templateUninstaller.UnInstallAsync(csProjPath, ct);

        var codeProcess = new Process
                          {
                              StartInfo = new ProcessStartInfo
                                          {
                                              FileName = "C:\\Program Files\\Microsoft VS Code\\Code.exe"
                                            , ArgumentList =
                                              {
                                                  generationContext.Path
                                                , "-n"
                                              }
                                            , RedirectStandardInput  = true
                                            , RedirectStandardOutput = true
                                            , RedirectStandardError  = true
                                            , CreateNoWindow         = false
                                          }
                          };

        codeProcess.Start();
        await codeProcess.WaitForExitAsync(ct);
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
