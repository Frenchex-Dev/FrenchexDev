#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain.Abstractions;

public interface IPackagesInstaller
{
    Task InstallAsync(
        ICsProjPath              csProjPath
      , IList<IPackageReference> packages
      , CancellationToken        cancellationToken = default
    );
}
