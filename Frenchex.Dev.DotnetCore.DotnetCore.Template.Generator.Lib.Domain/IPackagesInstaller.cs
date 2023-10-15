#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain.Abstractions;

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain;

public interface IPackagesInstaller
{
    Task InstallAsync(
        ICsProjPath              csProjPath
      , IList<IPackageReference> packages
      , CancellationToken        cancellationToken = default
    );
}
