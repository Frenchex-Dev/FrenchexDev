#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

#endregion

#region Usings

using Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain.Abstractions;

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain;

public interface ITemplateInstaller
{
    Task<ITemplateInstallationResult> InstallAsync(
        ICsProjPath       csProjPath
      , CancellationToken cancellationToken = default
    );
}
