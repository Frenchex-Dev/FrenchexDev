#region Usings

using Frenchex.Dev.DotnetCore.Process.Lib.Domain;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Halt;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Infrastructure.Commands.Halt;

/// <summary>
/// </summary>
public class VagrantHaltCommand : AbstractVagrantCommand, IVagrantHaltCommand
{
    private readonly IVagrantHaltCommandLineBuilder _commandLineBuilder;

    public VagrantHaltCommand(
        IProcessStarterFactory         processStarterFactory
      , IVagrantHaltCommandLineBuilder commandLineBuilder
    ) : base(processStarterFactory)
    {
        _commandLineBuilder = commandLineBuilder;
    }

    public async Task<VagrantHaltResponse> StartAsync(
        VagrantHaltRequest                request
      , IVagrantCommandExecutionContext   context
      , IVagrantCommandExecutionListeners listeners
    )
    {
        var processContext = new ProcessExecutionContext(context.WorkingDirectory, "vagrant"
                                                       , _commandLineBuilder.BuildCommandLineArguments(request)
                                                       , new Dictionary<string, string>(), false, false);

        var processStarter = ProcessStarterFactory.Factory();

        var process = await processStarter.StartAsync(processContext);

        var response = new VagrantHaltResponse(process.ExitCode);

        return response;
    }
}
