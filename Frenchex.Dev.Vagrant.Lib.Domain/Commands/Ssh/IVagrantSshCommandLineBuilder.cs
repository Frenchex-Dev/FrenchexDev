#region Usings

using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Ssh;

public interface IVagrantSshCommandLineBuilder : IVagrantCommandLineBuilder<VagrantSshRequest>
{
}
