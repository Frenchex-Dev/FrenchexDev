using Frenchex.Dev.DotnetCore.Process.Lib;
using Frenchex.Dev.DotnetCore.Process.Lib.Domain;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Init;

namespace Frenchex.Dev.Vagrant.Lib.Infrastructure.Commands.Init;

/// <summary>
/// 
/// </summary>
public class VagrantInitCommand : AbstractVagrantCommand, IVagrantInitCommand
{
    public VagrantInitCommand(IProcess processExecutor) : base(processExecutor)
    {
    }

    public async Task<VagrantInitResponse> StartAsync(
        VagrantInitRequest request,
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

        var response = new VagrantInitResponse(process.ExitCode);

        return response;
    }


    public Task StopAsync(TimeSpan timeOut)
    {
        throw new NotImplementedException();
    }

    protected override string[] BuildVagrantArgumentsAndOptions(IVagrantCommandRequest request, IVagrantCommandExecutionContext context)
    {
        if (!(request is VagrantInitRequest vagrantInitRequest))
        {
            return Array.Empty<string>();
        }

        var arguments = new List<string>() { "init" };

        return arguments.ToArray();
    }
}