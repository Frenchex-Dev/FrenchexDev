using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Root;

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Ssh;

public class SshCommandRequestBuilder : RootCommandRequestBuilder, ISshCommandRequestBuilder
{
    private string? _command;
    private string? _extraSshArgs;
    private string? _nameOrId;
    private bool? _plain;
    private bool? _withColor;

    public SshCommandRequestBuilder(
        IBaseCommandRequestBuilderFactory? baseRequestBuilderFactory
    ) : base(baseRequestBuilderFactory)
    {
    }

    public ISshCommandRequest Build()
    {
        return new SshCommandRequest(
            _nameOrId ?? "",
            _command ?? "",
            _plain ?? false,
            _extraSshArgs ?? "",
            _withColor ?? false,
            BaseBuilder.Build()
        );
    }

    public ISshCommandRequestBuilder UsingNameOrId(string nameOrId)
    {
        _nameOrId = nameOrId;
        return this;
    }

    public ISshCommandRequestBuilder UsingCommand(string command)
    {
        _command = command;
        return this;
    }

    public ISshCommandRequestBuilder WithPlain(bool with)
    {
        _plain = with;
        return this;
    }

    public ISshCommandRequestBuilder WithColor(bool withColor)
    {
        _withColor = withColor;
        return this;
    }

    public ISshCommandRequestBuilder UsingExtraSshArgs(string extra)
    {
        _extraSshArgs = extra;
        return this;
    }
}