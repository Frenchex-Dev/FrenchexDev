#region Usings

using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Ssh;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Abstractions;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Ssh;

public class VagrantSshRequestBuilder : AbstractVagrantRequestBuilder, IVagrantSshRequestBuilder
{
    private string _command      = string.Empty;
    private string _extraSshArgs = string.Empty;
    private string _nameOrId     = string.Empty;

    public VagrantSshRequest Build()
    {
        return new VagrantSshRequest(_nameOrId, _extraSshArgs, _command, BaseBuilder.Color, BaseBuilder.MachineReadable
                                   , BaseBuilder.Version, BaseBuilder.Debug, BaseBuilder.Timestamp
                                   , BaseBuilder.DebugTimestamp, BaseBuilder.NoTty, BaseBuilder.Help);
    }

    public IVagrantSshRequestBuilder WithNameOrId(
        string nameOrId
    )
    {
        _nameOrId = nameOrId;
        return this;
    }

    public IVagrantSshRequestBuilder WithCommand(
        string command
    )
    {
        _command = command;
        return this;
    }

    public IVagrantSshRequestBuilder WithExtraSshArgs(
        string extraSshArgs
    )
    {
        _extraSshArgs = extraSshArgs;
        return this;
    }
}
