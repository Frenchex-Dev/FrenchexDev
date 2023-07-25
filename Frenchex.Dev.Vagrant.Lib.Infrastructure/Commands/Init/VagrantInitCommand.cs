#region Usings

using Frenchex.Dev.DotnetCore.Process.Lib.Domain;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Init;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Infrastructure.Commands.Init;

/// <summary>
/// </summary>
public class VagrantInitCommand : AbstractVagrantCommand, IVagrantInitCommand
{
    private readonly IVagrantInitCommandLineBuilder _vagrantInitCommandLineBuilder;

    public VagrantInitCommand(
        IProcessStarterFactory         processExecutor
      , IVagrantInitCommandLineBuilder vagrantInitCommandLineBuilder
    ) : base(processExecutor)
    {
        _vagrantInitCommandLineBuilder = vagrantInitCommandLineBuilder;
    }

    public async Task<VagrantInitResponse> StartAsync(
        VagrantInitRequest                request
      , IVagrantCommandExecutionContext   context
      , IVagrantCommandExecutionListeners listeners
    )
    {
        var processContext
            = CreateProcessExecutionContext(request, context
                                 ,                   _vagrantInitCommandLineBuilder.BuildCommandLineArguments(request));

        var processStarter = ProcessStarterFactory.Factory();

        PrepareProcess(listeners, processStarter);

        var process = await processStarter.StartAsync(processContext);

        await WaitProcessForExitAsync(context, process);

        var response = new VagrantInitResponse(process.ExitCode);

        return response;
    }
}
