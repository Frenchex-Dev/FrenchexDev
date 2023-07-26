namespace Frenchex.Dev.Packer.Lib.Domain.Abstractions;

/// <summary>
///     <para>
///     </para>
/// </summary>
public interface IPackerCommand<in TRequest, TResponse> where TRequest : IPackerCommandRequest
                                                        where TResponse : IPackerCommandResponse
{
    /// <summary>
    /// </summary>
    /// <param name="request"></param>
    /// <param name="context"></param>
    /// <param name="listeners"></param>
    /// <returns></returns>
    Task<TResponse> StartAsync(
        TRequest                         request
      , IPackerCommandExecutionContext   context
      , IPackerCommandExecutionListeners listeners
    );
}

public interface IPackerCommandRequest
{
}

public interface IPackerCommandResponse
{
}

public interface IPackerCommandExecutionContext
{
}

public interface IPackerCommandExecutionListeners
{
}

public interface IPackerCommandLineBuilder<in TRequest> where TRequest : IPackerCommandRequest
{
    string BuildCommandLineArguments(
        TRequest request
    );
}

public interface IPackerRequestBuilder<out TRequest>
{
    TRequest Build();
}
