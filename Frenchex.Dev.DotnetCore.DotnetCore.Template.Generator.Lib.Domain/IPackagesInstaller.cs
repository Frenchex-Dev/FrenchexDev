using Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain.Abstractions;

namespace Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain;

public interface IPackagesInstaller
{
    Task InstallAsync(
        ICsProjPath              csProjPath
      , IList<IPackageReference> packages
      , CancellationToken        cancellationToken = default
    );
}
