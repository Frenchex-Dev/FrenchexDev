#region Licensing

// Licensing please read LICENSE.md

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands;

public interface IVagrantCommandsFacade
{
    Task<IVagrantCommandResponse> StartAsync(
        IVagrantCommandRequest            request
      , IVagrantCommandExecutionContext   executionContext
      , IVagrantCommandExecutionListeners executionListeners
      , CancellationToken                 cancellationToken = default
    );
}
