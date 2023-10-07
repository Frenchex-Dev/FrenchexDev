#region Licensing

// Licensing please read LICENSE.md

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Solution.AddProject.Lib.Domain.Abstractions;

public class SolutionDoesNotExistException : Exception
{
    public SolutionDoesNotExistException(
        string message
    ) : base(message)
    {
    }
}
