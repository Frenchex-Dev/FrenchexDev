#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Destroy;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Destroy;

public class VagrantDestroyResponseBuilder : IVagrantDestroyResponseBuilder
{
    public Task<IVagrantDestroyResponse> BuildAsync(
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

        return Task.FromResult<IVagrantDestroyResponse>(new VagrantDestroyResponse(exitCode));
    }
}
