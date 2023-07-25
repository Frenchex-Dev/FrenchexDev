#region Usings

using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.SshConfig;

public interface IVagrantSshConfigCommandLineBuilder : IVagrantCommandLineBuilder<VagrantSshConfigRequest>
{
}
