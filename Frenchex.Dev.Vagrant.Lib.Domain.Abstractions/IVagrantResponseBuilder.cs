#region Licensing

// Licensing please read LICENSE.md

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Abstractions;

public interface IVagrantResponseBuilder<TResponse>
{
    Task<TResponse> BuildAsync(
        IList<string>     stdOut
      , IList<string>     stdErr
      , int               exitCode
      , CancellationToken cancellationToken = default
    );
}
