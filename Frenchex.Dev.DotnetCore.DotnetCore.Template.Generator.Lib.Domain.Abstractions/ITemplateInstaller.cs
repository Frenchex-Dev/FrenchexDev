#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain.Abstractions
{
    public interface ITemplateInstaller
    {
        Task InstallAsync(
            ICsProjPath       csProjPath
          , CancellationToken cancellationToken = default
        );
    }
}
