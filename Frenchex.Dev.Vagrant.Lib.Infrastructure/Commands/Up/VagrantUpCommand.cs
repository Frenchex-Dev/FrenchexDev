using Frenchex.Dev.DotnetCore.Process.Lib;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Up;

namespace Frenchex.Dev.Vagrant.Lib.Infrastructure.Commands.Up;

/// <summary>
/// <inheritdoc cref="IVagrantUpCommand"/>
/// </summary>
public class VagrantUpCommand : AbstractVagrantCommand, IVagrantUpCommand
{
    public VagrantUpCommand(IProcess processExecutor) : base(processExecutor)
    {
    }

    public async Task<UpCommandResponse> StartAsync(
        UpCommandRequest request,
        IVagrantCommandExecutionContext context,
        IVagrantCommandExecutionListeners listeners)
    {
        var processContext = new ProcessExecutionContext(
            path: context.WorkingDirectory,
            binary: "vagrant",
            arguments: BuildVagrantArgumentsAndOptions(request, context),
            environment: new Dictionary<string, string>(),
            saveStdOutStream: false,
            saveStdErrStream: false
        );

        var process = await ProcessExecutor.StartAsync(processContext);

        var response = new UpCommandResponse(process.ExitCode);

        return response;
    }

    public Task StopAsync(TimeSpan timeOut)
    {
        throw new NotImplementedException();
    }

    protected override string[] BuildVagrantArgumentsAndOptions<TRequest>(TRequest request, IVagrantCommandExecutionContext context)
    {

    }
}