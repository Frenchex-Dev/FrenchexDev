namespace Frenchex.Dev.Vagrant.Lib.Domain.Abstractions;

/// <summary>
///     <para>
///     </para>
/// </summary>
public interface IVagrantCommand<in TRequest, TResponse> where TRequest : IVagrantCommandRequest
                                                         where TResponse : IVagrantCommandResponse
{
    /// <summary>
    /// </summary>
    /// <param name="request"></param>
    /// <param name="context"></param>
    /// <param name="listeners"></param>
    /// <returns></returns>
    Task<TResponse> StartAsync(
        TRequest                          request
      , IVagrantCommandExecutionContext   context
      , IVagrantCommandExecutionListeners listeners
    );
}
