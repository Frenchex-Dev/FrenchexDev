#region Licensing

// Licensing please read LICENSE.md

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain.Abstractions;

public class PackageInstallationException : Exception
{
    public PackageInstallationException(
        string message
    ) : base(message)
    {
    }
}