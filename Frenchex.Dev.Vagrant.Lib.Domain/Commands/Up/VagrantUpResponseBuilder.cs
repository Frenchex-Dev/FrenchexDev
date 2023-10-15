#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Up;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Up;

public class VagrantUpResponseBuilder : IVagrantUpResponseBuilder
{
    public Task<IVagrantUpResponse> BuildAsync(
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

        return Task.FromResult<IVagrantUpResponse>(new VagrantUpResponse(exitCode));
    }
}
