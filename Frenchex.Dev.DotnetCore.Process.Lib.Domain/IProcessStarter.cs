namespace Frenchex.Dev.DotnetCore.Process.Lib.Domain;

/// <summary>
/// 
/// </summary>
public interface IProcessStarter
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    IProcessExecution Start(IProcessExecutionContext context, CancellationToken cancellationToken = default);
}