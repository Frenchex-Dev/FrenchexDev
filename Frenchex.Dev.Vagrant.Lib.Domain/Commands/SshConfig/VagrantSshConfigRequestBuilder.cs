#region Usings

using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Abstractions;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.SshConfig;

public class VagrantSshConfigRequestBuilder : AbstractVagrantRequestBuilder, IVagrantSshConfigRequestBuilder
{
    private string _host     = string.Empty;
    private string _nameOrId = string.Empty;

    public VagrantSshConfigRequest Build()
    {
        return new VagrantSshConfigRequest(_nameOrId, _host, BaseBuilder.Color, BaseBuilder.MachineReadable
                                         , BaseBuilder.Version, BaseBuilder.Debug, BaseBuilder.Timestamp
                                         , BaseBuilder.DebugTimestamp, BaseBuilder.NoTty, BaseBuilder.Help);
    }

    public IVagrantSshConfigRequestBuilder WithNameOrId(string nameOrId)
    {
        _nameOrId = nameOrId;
        return this;
    }

    public IVagrantSshConfigRequestBuilder WithHost(string host)
    {
        _host = host;
        return this;
    }
}
