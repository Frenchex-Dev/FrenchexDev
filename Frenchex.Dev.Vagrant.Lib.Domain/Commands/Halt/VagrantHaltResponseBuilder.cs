#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Halt;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Halt;

public class VagrantHaltResponseBuilder : IVagrantHaltResponseBuilder
{
    public Task<IVagrantHaltResponse> BuildAsync(
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

        return Task.FromResult<IVagrantHaltResponse>(new VagrantHaltResponse(exitCode));
    }
}
