using System.CommandLine;
using Frenchex.Dev.Vos.Cli.Integration.Domain.Arguments;
using Frenchex.Dev.Vos.Cli.Integration.Domain.Options;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Halt;

namespace Frenchex.Dev.Vos.Cli.Integration.Domain.Commands.Halt;

public class HaltCommandIntegration : ABaseCommandIntegration, IHaltCommandIntegration
{
    private readonly IHaltCommand _command;
    private readonly IForceOptionBuilder _forceOptionBuilder;
    private readonly INamesArgumentBuilder _namesArgumentBuilder;
    private readonly IHaltCommandRequestBuilderFactory _responseBuilderFactory;

    public HaltCommandIntegration(
        IHaltCommand command,
        IHaltCommandRequestBuilderFactory responseBuilder,
        INamesArgumentBuilder namesArgumentBuilder,
        IForceOptionBuilder forceOptionBuilder,
        ITimeoutMsOptionBuilder timeoutMsOptionBuilder,
        IWorkingDirectoryOptionBuilder workingDirectoryOptionBuilder,
        IVagrantBinPathOptionBuilder vagrantBinPathOptionBuilder
    ) : base(workingDirectoryOptionBuilder, timeoutMsOptionBuilder, vagrantBinPathOptionBuilder)
    {
        _command = command;
        _responseBuilderFactory = responseBuilder;
        _namesArgumentBuilder = namesArgumentBuilder;
        _forceOptionBuilder = forceOptionBuilder;
    }

    public void Integrate(Command parentCommand)
    {
        Argument<string[]> namesArg = _namesArgumentBuilder.Build();
        Option<bool> forceOpt = _forceOptionBuilder.Build();
        Option<int> haltTimeoutMsOpt = TimeoutMsOptionBuilder.Build(
            new[] {"--halt-timeoutms"},
            () => (int) TimeSpan.FromMinutes(1).TotalMilliseconds,
            "Halt timeout in ms"
        );

        Option<int> timeoutMsOpt = TimeoutMsOptionBuilder.Build();
        Option<string> workingDirOpt = WorkingDirectoryOptionBuilder.Build();
        Option<string> vagrantBinPath = VagrantBinPathOptionBuilder.Build();

        var command = new Command("halt", "Runs Vagrant halt") {
            namesArg,
            forceOpt,
            haltTimeoutMsOpt,
            timeoutMsOpt,
            workingDirOpt,
            vagrantBinPath
        };

        var binder = new HaltCommandIntegrationPayloadBinder(
            namesArg,
            forceOpt,
            haltTimeoutMsOpt,
            timeoutMsOpt,
            workingDirOpt,
            vagrantBinPath
        );

        command.SetHandler(async context =>
        {
            var payload = binder.GetBoundValue(context);
            var requestBuilder = _responseBuilderFactory.Factory();

            BuildBase(requestBuilder, payload);

            var response = await _command.ExecuteAsync(requestBuilder
                    .UsingNames(payload.Names)
                    .WithForce(payload.Force)
                    .UsingHaltTimeoutInMiliSeconds(payload.HaltTimeoutMs)
                    .Build()
                )
                ;

            if (null == response.Response.ProcessExecutionResult.WaitForCompleteExit)
                throw new InvalidOperationException("missing response elements");

            response.Response.Process.WrappedProcess.OutputDataReceived += (sender, args) =>
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