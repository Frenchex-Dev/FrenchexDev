#region Usings

using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Destroy;

public interface IVagrantDestroyCommandLineBuilder : IVagrantCommandLineBuilder<VagrantDestroyRequest>
{
}
