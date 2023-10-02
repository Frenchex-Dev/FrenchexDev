namespace Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain.Abstractions;

public class ProcessNotStartedException : Exception
{
    public ProcessNotStartedException(
        string message
    ) : base(message)
    {
    }
}
