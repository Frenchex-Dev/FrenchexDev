namespace Frenchex.Dev.Dotnet.Core.Solution.Lib.Domain.Base.Structure;

public class DirectoryStructureGenerator : BasePathBasedActionWrapper
{
    public DirectoryStructureGenerator(Action<string> wrappedAction) : base(wrappedAction)
    {
    }
}