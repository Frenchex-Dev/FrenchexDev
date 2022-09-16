using System.CommandLine.Invocation;

namespace Frenchex.Dev.Vos.Cli.Integration.Domain;

public interface IGenericBinder<T>
{
    public T GetBoundValue(InvocationContext invocationContext);
}