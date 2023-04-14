using Frenchex.Dev.DotnetCore.Process.Lib.Domain;

namespace Frenchex.Dev.DotnetCore.Process.Lib.Infrastructure;

public class ProcessStarter : IProcessStarter
{
    public IProcessExecution Start(
        IProcessExecutionContext context,
        CancellationToken cancellationToken = default
    )
    {
        var process = new System.Diagnostics.Process()
        {
            StartInfo =
            {
                WorkingDirectory = context.WorkingDirectory,
                Arguments = string.Join(" ", context.Arguments),
                CreateNoWindow = false,
                UseShellExecute = false,
                RedirectStandardError = true,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
            }
        };

        var started = process.Start();

        var tcsFinished = new TaskCompletionSource();

        process.OutputDataReceived += async (_, e) =>
        {
            if (e.Data == null)
            {
                tcsFinished.TrySetResult();
                return;
            };

            foreach (var handler in context.GetStdOutListeners())
            {
                await handler(e.Data);
            }
        };

        process.ErrorDataReceived += async (_, e) =>
        {
            if (e.Data == null)
            {
                tcsFinished.TrySetResult();
                return;
            };

            foreach (var handler in context.GetStdErrListeners())
            {
                await handler(e.Data);
            }
        };


        var processExecution = new ProcessExecution(process, started, tcsFinished.Task);

        return processExecution;
    }
}