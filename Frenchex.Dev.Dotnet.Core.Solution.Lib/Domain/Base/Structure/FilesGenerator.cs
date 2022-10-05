namespace Frenchex.Dev.Dotnet.Core.Solution.Lib.Domain.Base.Structure;

public class FilesGenerator : BasePathBasedActionWrapper
{
    public FilesGenerator(Action<string> wrappedAction) : base(wrappedAction)
    {
    }
}