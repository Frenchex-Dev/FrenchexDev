#region Licensing

// Licensing please read LICENSE.md

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Abstractions
{
    /// <summary>
    ///     <para>
    ///         Gives developers opportunity to add listeners to stdout and stderr
    ///     </para>
    /// </summary>
    public interface IVagrantCommandExecutionListeners
    {
        /// <summary>
        /// </summary>
        /// <param name="listener"></param>
        /// <returns></returns>
        IVagrantCommandExecutionListeners AddStdOutListener(
            Func<string, Task> listener
        );

        /// <summary>
        /// </summary>
        /// <returns></returns>
        List<Func<string, Task>> GetStdOutListeners();

        /// <summary>
        /// </summary>
        /// <param name="listener"></param>
        /// <returns></returns>
        IVagrantCommandExecutionListeners AddStdErrListener(
            Func<string, Task> listener
        );

        /// <summary>
        /// </summary>
        /// <returns></returns>
        List<Func<string, Task>> GetStdErrListeners();
    }
}
