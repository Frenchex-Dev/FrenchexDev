using Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain.Abstractions;

namespace Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain;

public interface ITemplateInstaller
{
    Task InstallAsync(
        ICsProjPath       csProjPath
      , CancellationToken cancellationToken = default
    );
}