#region Licensing

// Licensing please read LICENSE.md

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Project.AddPackage.Lib.Domain.Abstractions;

public class ProcessNotStartedException : Exception
{
    public ProcessNotStartedException(
        string message
    ) : base(message)
    {
    }
}
