#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Status;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Status;

public class VagrantStatusResponseBuilder : IVagrantStatusResponseBuilder
{
    public Task<IVagrantStatusResponse> BuildAsync(
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

        return Task.FromResult<IVagrantStatusResponse>(new VagrantStatusResponse(exitCode));
    }
}
