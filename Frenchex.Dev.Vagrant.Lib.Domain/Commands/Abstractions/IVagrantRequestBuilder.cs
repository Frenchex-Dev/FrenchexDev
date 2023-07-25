namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Abstractions;

/// <summary>
/// </summary>
/// <typeparam name="TRequest"></typeparam>
public interface IVagrantRequestBuilder<out TRequest>
{
    /// <summary>
    /// </summary>
    /// <returns></returns>
    TRequest Build();

    IBaseVagrantCommandRequestBuilder Base();
}
