#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.DotnetCore.Process.Lib.Domain;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Halt;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Infrastructure.Commands.Halt
{
    /// <summary>
    /// </summary>
    public class VagrantHaltCommand(
        IProcessStarterFactory         processStarterFactory
      , IVagrantHaltCommandLineBuilder commandLineBuilder
    ) : AbstractVagrantCommand(processStarterFactory), IVagrantHaltCommand
    {
        public async Task<VagrantHaltResponse> StartAsync(
            VagrantHaltRequest                request
          , IVagrantCommandExecutionContext   context
          , IVagrantCommandExecutionListeners listeners
        )
        {
            var processContext = CreateProcessExecutionContext(context, commandLineBuilder.BuildCommandLineArguments(request));

            var processStarter = ProcessStarterFactory.Factory();

            PrepareProcess(listeners, processStarter);

            var process = await processStarter.StartAsync(processContext);

            await WaitProcessForExitAsync(context, process);

            var response = new VagrantHaltResponse(process.ExitCode);

            return response;
        }
    }
}
