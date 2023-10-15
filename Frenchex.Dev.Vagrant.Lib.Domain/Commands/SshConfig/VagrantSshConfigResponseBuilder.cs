#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.SshConfig;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.SshConfig;

public class VagrantSshConfigResponseBuilder : IVagrantSshConfigResponseBuilder
{
    public Task<IVagrantSshConfigResponse> BuildAsync(
        IList<string>     stdOut
      , IList<string>     stdErr
      , int               exitCode
      , CancellationToken cancellationToken = default
    )
    {
        if (stdErr.Count > 0)
        {
        }

        if (stdOut.Count > 0)
        {
        }

        return Task.FromResult<IVagrantSshConfigResponse>(new VagrantSshConfigResponse(exitCode));
    }
}
