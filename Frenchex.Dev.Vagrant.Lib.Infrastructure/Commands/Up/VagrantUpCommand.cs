#region Usings

using Frenchex.Dev.DotnetCore.Process.Lib.Domain;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Up;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Infrastructure.Commands.Up;

/// <summary>
///     <inheritdoc cref="IVagrantUpCommand" />
/// </summary>
public class VagrantUpCommand : AbstractVagrantCommand, IVagrantUpCommand
{
    private readonly IVagrantUpCommandLineBuilder _vagrantUpCommandLineBuilder;

    public VagrantUpCommand(
        IProcessStarterFactory       processStarterFactory
      , IVagrantUpCommandLineBuilder vagrantUpCommandLineBuilder
    ) : base(processStarterFactory)
    {
        _vagrantUpCommandLineBuilder = vagrantUpCommandLineBuilder;
    }

    public async Task<UpCommandResponse> StartAsync(
        VagrantUpRequest                  request
      , IVagrantCommandExecutionContext   context
      , IVagrantCommandExecutionListeners listeners
    )
    {
        var processContext = new ProcessExecutionContext(context.WorkingDirectory, context.VagrantBin
                                                       , _vagrantUpCommandLineBuilder.BuildCommandLineArguments(request)
                                                       , context.Environment, context.SaveStdOutStream
                                                       , context.SaveStdErrStream);

        var processStarter = ProcessStarterFactory.Factory();

        foreach (var listener in listeners.GetStdErrListeners())
            processStarter.AddProcessPreparer(async process => { });

        var process = await processStarter.StartAsync(processContext);

        var response = new UpCommandResponse(process.ExitCode);

        return response;
    }
}
