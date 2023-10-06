#region Licensing

// Licensing please read LICENSE.md

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Base
{
    /// <summary>
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    public interface IVagrantRequestBuilder<out TRequest> where TRequest : IVagrantCommandRequest
    {
        /// <summary>
        /// </summary>
        /// <returns></returns>
        TRequest Build();

        IBaseVagrantCommandRequestBuilder Base();
    }
}
