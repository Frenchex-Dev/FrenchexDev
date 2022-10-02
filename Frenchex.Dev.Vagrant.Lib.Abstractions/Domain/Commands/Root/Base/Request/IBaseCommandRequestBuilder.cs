using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Root.Request;

namespace Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Root.Base.Request;

public interface IBaseCommandRequestBuilder
{
    IBaseCommandRequest Build();
    T Parent<T>() where T : IRootCommandRequestBuilder;
    IBaseCommandRequestBuilder WithColor(bool with);
    IBaseCommandRequestBuilder WithMachineReadable(bool with);
    IBaseCommandRequestBuilder WithVersion(bool with);
    IBaseCommandRequestBuilder WithDebug(bool with);
    IBaseCommandRequestBuilder WithTimestamp(bool with);
    IBaseCommandRequestBuilder WithTty(bool with);
    IBaseCommandRequestBuilder WithHelp(bool with);
    IBaseCommandRequestBuilder UsingWorkingDirectory(string? workingDirectory);
    IBaseCommandRequestBuilder UsingTimeout(string? timeout);
}