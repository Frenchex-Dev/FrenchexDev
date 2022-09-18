namespace Frenchex.Dev.Dotnet.Wrapping.Lib.Domain.Commands.Root;

public interface IBaseCommandRequestBuilder
{
    IBaseCommandRequest Build();
    T Parent<T>() where T : IRootCommandRequestBuilder;
    IBaseCommandRequestBuilder UsingWorkingDirectory(string? workingDirectory);
    IBaseCommandRequestBuilder UsingTimeoutMs(int timeoutMs);
    IBaseCommandRequestBuilder WithTty(bool with);
    IBaseCommandRequestBuilder UsingBinPath(string binPath);
}