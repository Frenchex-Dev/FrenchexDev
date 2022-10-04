namespace Frenchex.Dev.Dotnet.Core.Cli.Lib.Abstractions.Domain;

public interface IProgram : IAsyncDisposable, IDisposable
{
    Task RunAsync();
}