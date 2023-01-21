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
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Up.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Up.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Up.Response;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Definitions;

#endregion

namespace Frenchex.Dev.Vos.Cli.Integration.Domain.Commands.Up;

public class UpCommandIntegration : ABaseCommandIntegration, IUpCommandIntegration
{
    private readonly IUpCommand _command;
    private readonly INamesArgumentBuilder _namesArgumentBuilder;
    private readonly IParallelOptionBuilder _parallelOptionBuilder;
    private readonly IParallelWaitOptionBuilder _parallelWaitOptionBuilder;
    private readonly IParallelWorkersOptionBuilder _parallelWorkersOptionBuilder;
    private readonly IUpCommandRequestBuilderFactory _requestBuilderFactory;

    public UpCommandIntegration(
        IUpCommand command,
        IUpCommandRequestBuilderFactory requestBuilderFactory,
        INamesArgumentBuilder namesArgumentBuilder,
        IParallelOptionBuilder parallelOptionBuilder,
        IParallelWorkersOptionBuilder parallelWorkersOptionBuilder,
        IParallelWaitOptionBuilder parallelWaitOptionBuilder,
        ITimeoutMsOptionBuilder timeoutStrOptionBuilder,
        IWorkingDirectoryOptionBuilder workingDirectoryOptionBuilder,
        IVagrantBinPathOptionBuilder vagrantBinPathOptionBuilder
    ) : base(workingDirectoryOptionBuilder, timeoutStrOptionBuilder, vagrantBinPathOptionBuilder)
    {
        _command = command;
        _requestBuilderFactory = requestBuilderFactory;
        _namesArgumentBuilder = namesArgumentBuilder;
        _parallelOptionBuilder = parallelOptionBuilder;
        _parallelWorkersOptionBuilder = parallelWorkersOptionBuilder;
        _parallelWaitOptionBuilder = parallelWaitOptionBuilder;
    }

    public void IntegrateInto(Command parentCommand)
    {
        var namesArg = _namesArgumentBuilder.Build();
        var provisionOpt = new Option<bool>(new[] { "--provision" }, "Provision");
        var provisionWithOpt = new Option<string[]>(new[] { "--provision-with" }, "Provision with");
        var destroyOnErrorOpt = new Option<bool>(new[] { "--destroy-on-error" }, "Destroy on error");
        var parallelOpt = _parallelOptionBuilder.Build();
        var parallelWorkers = _parallelWorkersOptionBuilder.Build();
        var parallelWait = _parallelWaitOptionBuilder.Build();
        var providerOpt =
            new Option<string>(new[] { "--provider" }, () => ProviderEnum.Virtualbox.ToString(), "Provider");

        var installProviderOpt = new Option<bool>(new[] { "--install-provider", "-i" }, "Install provider");
        var timeout = TimeoutStrOptionBuilder.Build();
        var workingDirOpt = WorkingDirectoryOptionBuilder.Build();
        var vagrantBinPath = VagrantBinPathOptionBuilder.Build();

        var command = new Command("up", "Runs Vagrant up")
        {
            namesArg,
            provisionOpt,
            provisionWithOpt,
            destroyOnErrorOpt,
            parallelOpt,
            parallelWorkers,
            parallelWait,
            providerOpt,
            installProviderOpt,
            timeout,
            workingDirOpt,
            vagrantBinPath
        };

        var binder = new UpCommandIntegrationPayloadBinder(
            namesArg,
            provisionOpt,
            provisionWithOpt,
            destroyOnErrorOpt,
            parallelOpt,
            parallelWorkers,
            parallelWait,
            providerOpt,
            installProviderOpt,
            timeout,
            workingDirOpt,
            vagrantBinPath
        );

        command.SetHandler(async context =>
        {
            UpCommandIntegrationPayload? payload = binder.GetBoundValue(context);
            IUpCommandRequestBuilder? requestBuilder = _requestBuilderFactory.Factory();

            BuildBase(requestBuilder, payload);

            IUpCommandResponse? response = await _command
                    .ExecuteAsync(requestBuilder
                        .UsingNames(payload.Names!.ToArray())
                        .WithProvision(payload.Provision)
                        .UsingProvisionWith(payload.ProvisionWith!)
                        .WithDestroyOnError(payload.DestroyOnError)
                        .WithParallel(payload.Parallel)
                        .UsingProvider(payload.Provider!)
                        .WithInstallProvider(payload.InstallProvider)
                        .Build()
                    )
                ;

            if (null == response.Response.ProcessExecutionResult.WaitForCompleteExit)
                throw new InvalidOperationException("missing response elements");

            response.Response.Process.WrappedProcess.OutputDataReceived += (_, args) =>
            {
                if (args.Data != null) context.Console.Out.Write(args.Data + "\r\n");
            };

            Console.CancelKeyPress += delegate
            {
                Console.WriteLine("Cancel key pressed. Cleaning...");
                response.Response.Process.Stop();
                Console.WriteLine("Exiting");
            };

            await response.Response.ProcessExecutionResult.WaitForCompleteExit;
        });

        parentCommand.AddCommand(command);
    }
}