using System.CommandLine;
using Frenchex.Dev.Vos.Cli.Integration.Domain.Arguments;
using Frenchex.Dev.Vos.Cli.Integration.Domain.Options;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Up.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Up.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Definitions;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Up;

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

    public void Integrate(Command parentCommand)
    {
        Argument<string[]> namesArg = _namesArgumentBuilder.Build();
        Option<bool> provisionOpt = new(new[] {"--provision"}, "Provision");
        Option<string[]> provisionWithOpt = new(new[] {"--provision-with"}, "Provision with");
        Option<bool> destroyOnErrorOpt = new(new[] {"--destroy-on-error"}, "Destroy on error");
        Option<bool> parallelOpt = _parallelOptionBuilder.Build();
        Option<int> parallelWorkers = _parallelWorkersOptionBuilder.Build();
        Option<int> parallelWait = _parallelWaitOptionBuilder.Build();
        Option<string> providerOpt = new(new[] {"--provider"}, () => ProviderEnum.Virtualbox.ToString(), "Provider");

        Option<bool> installProviderOpt = new(new[] {"--install-provider", "-i"}, "Install provider");
        Option<String> timeout = TimeoutStrOptionBuilder.Build();
        Option<string> workingDirOpt = WorkingDirectoryOptionBuilder.Build();
        Option<string> vagrantBinPath = VagrantBinPathOptionBuilder.Build();

        var command = new Command("up", "Runs Vagrant up") {
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
            var payload = binder.GetBoundValue(context);
            var requestBuilder = _requestBuilderFactory.Factory();

            BuildBase(requestBuilder, payload);

            var response = await _command
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
                if (args.Data != null)
                {
                    context.Console.Out.Write(args.Data + "\r\n");
                }
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