﻿#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Init;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Init;

public class VagrantInitResponseBuilder : IVagrantInitResponseBuilder
{
    public Task<IVagrantInitResponse> BuildAsync(
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

        return Task.FromResult<IVagrantInitResponse>(new VagrantInitResponse(exitCode));
    }
}