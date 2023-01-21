#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using System.CommandLine;
using Frenchex.Dev.Vos.Cli.Integration.Domain.Arguments;
using Frenchex.Dev.Vos.Cli.Integration.Domain.Options;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Destroy.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Destroy.Request;

#endregion

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

    public void IntegrateInto(Command parentCommand)
    {
        var namesArg = _namesArgumentBuilder.Build();
        var forceOpt = _forceOptionBuilder.Build();
        var parallelOpt = _parallelOptionBuilder.Build();
        var gracefulOpt = _gracefulOptionBuilder.Build();
        var timeoutStrOpt = TimeoutStrOptionBuilder.Build();
        var workingDirOpt = WorkingDirectoryOptionBuilder.Build();
        var vagrantBinPath = VagrantBinPathOptionBuilder.Build();

        var command = new Command("destroy", "Runs Vex destroy")
        {
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
            DestroyCommandIntegrationPayload? payload = binder.GetBoundValue(context);
            IDestroyCommandRequestBuilder? requestBuilder = _requestBuilderFactory.Factory();

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