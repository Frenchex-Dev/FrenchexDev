using Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain.Abstractions;

namespace Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain;

public interface ITemplateUnInstaller
{
    Task UnInstallAsync(
        ICsProjPath       csProjPath
      , CancellationToken cancellationToken = default
    );
}
