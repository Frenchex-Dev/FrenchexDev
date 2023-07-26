#region Usings

using Frenchex.Dev.DotnetCore.Process.Lib.Domain;

#endregion

namespace Frenchex.Dev.DotnetCore.Process.Lib.Infrastructure;

public class ProcessStarter : IProcessStarter
{
    private readonly List<Func<System.Diagnostics.Process, Task>> _processPreparers;

    public ProcessStarter()
    {
        _processPreparers = new List<Func<System.Diagnostics.Process, Task>>();
    }

    public void AddProcessPreparer(
    Func<System.Diagnostics.Process, Task> processPreparer
    )
    {
        _processPreparers.Add(processPreparer);
    }

    public async Task<IProcessExecution> StartAsync(
    IProcessExecutionContext context
  , CancellationToken        cancellationToken = default
    )
    {
        var process = new System.Diagnostics.Process
                      {
                      StartInfo =
                      {
                      WorkingDirectory       = context.WorkingDirectory
                    , FileName               = context.Binary
                    , Arguments              = context.Arguments
                    , CreateNoWindow         = true
                    , UseShellExecute        = false
                    , RedirectStandardError  = true
                    , RedirectStandardInput  = true
                    , RedirectStandardOutput = true
                      }
                      };

        foreach (var preparer in _processPreparers) await preparer(process);

        var started = process.Start();

        var processExecution = new ProcessExecution(process, started);

        return processExecution;
    }
}
