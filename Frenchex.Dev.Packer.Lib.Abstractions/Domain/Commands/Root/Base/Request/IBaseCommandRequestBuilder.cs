namespace Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Root.Base.Request;

public interface IBaseCommandRequestBuilder : Dotnet.Core.Wrapping.Lib.Abstractions.Domain.Commands.Root.Base.Request.
    IBaseCommandRequestBuilder<IBaseCommandRequest>
{
    IBaseCommandRequestBuilder WithColor(bool with);
    IBaseCommandRequestBuilder WithMachineReadable(bool with);
    IBaseCommandRequestBuilder WithVersion(bool with);
    IBaseCommandRequestBuilder WithDebug(bool with);
    IBaseCommandRequestBuilder WithTimestamp(bool with);
    IBaseCommandRequestBuilder WithDebugTimestamp(bool with);
    IBaseCommandRequestBuilder WithTty(bool with);
    IBaseCommandRequestBuilder WithHelp(bool with);
}