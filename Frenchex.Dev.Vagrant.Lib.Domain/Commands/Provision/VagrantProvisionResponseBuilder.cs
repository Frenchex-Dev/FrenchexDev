#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Provision;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Provision;

public class VagrantProvisionResponseBuilder : IVagrantProvisionResponseBuilder
{
    public Task<IVagrantProvisionResponse> BuildAsync(
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

        return Task.FromResult<IVagrantProvisionResponse>(new VagrantProvisionResponse(exitCode));
    }
}
