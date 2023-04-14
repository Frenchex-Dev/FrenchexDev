namespace Frenchex.Dev.Vagrant.Lib.Domain.Abstractions;

/// <summary>
/// 
/// </summary>
public class VagrantCommandExecutionListeners : IVagrantCommandExecutionListeners
{
    private readonly List<Func<string, Task>> _stdOutListeners;
    private readonly List<Func<string, Task>> _stdErrListeners;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="stdOutListeners"></param>
    /// <param name="stdErrListeners"></param>
    public VagrantCommandExecutionListeners(List<Func<string, Task>>? stdOutListeners, List<Func<string, Task>>? stdErrListeners)
    {
        _stdOutListeners = stdOutListeners ?? new List<Func<string, Task>>();
        _stdErrListeners = stdErrListeners ?? new List<Func<string, Task>>();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="listener"></param>
    /// <returns></returns>
    public IVagrantCommandExecutionListeners AddStdOutListener(Func<string, Task> listener)
    {
        _stdOutListeners.Add(listener);
        return this;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="listener"></param>
    /// <returns></returns>
    public IVagrantCommandExecutionListeners AddStdErrListener(Func<string, Task> listener)
    {
        _stdErrListeners.Add(listener);
        return this;
    }
}