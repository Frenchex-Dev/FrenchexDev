#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Ssh;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Ssh;

public class VagrantSshResponseBuilder : IVagrantSshResponseBuilder
{
    public Task<IVagrantSshResponse> BuildAsync(
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

        return Task.FromResult<IVagrantSshResponse>(new VagrantSshResponse(exitCode));
    }
}
