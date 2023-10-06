#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.DotnetCore.Process.Lib.Domain;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.SshConfig;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Infrastructure.Commands.SshConfig
{
    public class VagrantSshConfigCommand(
        IProcessStarterFactory              processExecutor
      , IVagrantSshConfigCommandLineBuilder commandLineBuilder
    ) : AbstractVagrantCommand(processExecutor), IVagrantSshConfigCommand
    {
        public async Task<VagrantSshConfigResponse> StartAsync(
            VagrantSshConfigRequest           request
          , IVagrantCommandExecutionContext   context
          , IVagrantCommandExecutionListeners listeners
        )
        {
            var processContext = CreateProcessExecutionContext(context, commandLineBuilder.BuildCommandLineArguments(request));

            var processStarter = ProcessStarterFactory.Factory();

            PrepareProcess(listeners, processStarter);

            var process = await processStarter.StartAsync(processContext);

            await WaitProcessForExitAsync(context, process);

            var response = new VagrantSshConfigResponse(process.ExitCode);

            return response;
        }
    }
}
