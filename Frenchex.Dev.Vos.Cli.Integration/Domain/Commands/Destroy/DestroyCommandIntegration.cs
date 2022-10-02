using System.CommandLine;
using Frenchex.Dev.Vos.Cli.Integration.Domain.Arguments;
using Frenchex.Dev.Vos.Cli.Integration.Domain.Options;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Destroy.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Destroy.Request;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Destroy;

namespace Frenchex.Dev.Vos.Cli.Integration.Domain.Commands.Destroy;

public class DestroyCommandIntegration : ABaseCommandIntegration, IDestroyCommandIntegration
{
    private readonly IDestroyCommand _command;
    private readonly IForceOptionBuilder _forceOptionBuilder;
    private readonly IGracefulOptionBuilder _gracefulOptionBuilder;
    private readonly INamesArgumentBuilder _namesArgumentBuilder;
    private readonly IParallelOptionBuilder _parallelOptionBuilder;
    private readonly IDestroyCommandRequestBuilderFactory _requestBuilderFactory;

    public DestroyCommandIntegration(
        IDestroyCommand command,
        IDestroyCommandRequestBuilderFactory responseBuilderFactory,
        INamesArgumentBuilder namesArgumentBuilder,
        IForceOptionBuilder forceOptionBuilder,
        IParallelOptionBuilder parallelOptionBuilder,
        IGracefulOptionBuilder gracefulOptionBuilder,
        ITimeoutMsOptionBuilder timeoutStrOptionBuilder,
        IWorkingDirectoryOptionBuilder workingDirectoryOptionBuilder,
        IVagrantBinPathOptionBuilder vagrantBinPathOptionBuilder
    ) : base(workingDirectoryOptionBuilder, timeoutStrOptionBuilder, vagrantBinPathOptionBuilder)
    {
        _command = command;
        _requestBuilderFactory = responseBuilderFactory;
        _namesArgumentBuilder = namesArgumentBuilder;
        _forceOptionBuilder = forceOptionBuilder;
        _parallelOptionBuilder = parallelOptionBuilder;
        _gracefulOptionBuilder = gracefulOptionBuilder;
    }

    public void Integrate(Command parentCommand)
    {
        Argument<string[]> namesArg = _namesArgumentBuilder.Build();
        Option<bool> forceOpt = _forceOptionBuilder.Build();
        Option<bool> parallelOpt = _parallelOptionBuilder.Build();
        Option<bool> gracefulOpt = _gracefulOptionBuilder.Build();
        Option<string> timeoutStrOpt = TimeoutStrOptionBuilder.Build();
        Option<string> workingDirOpt = WorkingDirectoryOptionBuilder.Build();
        Option<string> vagrantBinPath = VagrantBinPathOptionBuilder.Build();

        var command = new Command("destroy", "Runs Vex destroy") {
            namesArg,
            forceOpt,
            parallelOpt,
            gracefulOpt,
            timeoutStrOpt,
            workingDirOpt,
            vagrantBinPath
        };

        var binder = new DestroyCommandIntegrationPayloadBinder(
            namesArg,
            forceOpt,
            gracefulOpt,
            timeoutStrOpt,
            workingDirOpt,
            vagrantBinPath
        );

        command.SetHandler(async context =>
        {
            var payload = binder.GetBoundValue(context);
            var requestBuilder = _requestBuilderFactory.Factory();

            BuildBase(requestBuilder, payload);

            await _command.ExecuteAsync(requestBuilder
                .UsingName(payload.NameOrId!.FirstOrDefault())
                .WithForce(payload.Force)
                .WithParallel(payload.Parallel)
                .WithGraceful(payload.Graceful)
                .Build()
            );
        });

        parentCommand.AddCommand(command);
    }
}