using System.CommandLine;
using Frenchex.Dev.Vos.Cli.Integration.Domain.Options;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Init;

namespace Frenchex.Dev.Vos.Cli.Integration.Domain.Commands.Init;

public class InitCommandIntegration : ABaseCommandIntegration, IInitCommandIntegration
{
    private readonly IInitCommand _command;
    private readonly INamingPatternOptionBuilder _namingPatternOptionBuilder;
    private readonly IInitCommandRequestBuilderFactory _responseBuilderFactory;
    private readonly IZeroesOptionBuilder _zeroesOptionBuilder;

    public InitCommandIntegration(
        IInitCommand command,
        IInitCommandRequestBuilderFactory responseBuilderFactory,
        INamingPatternOptionBuilder namingPatternOptionBuilder,
        IZeroesOptionBuilder zeroesOptionBuilder,
        ITimeoutMsOptionBuilder timeoutMsOptionBuilder,
        IWorkingDirectoryOptionBuilder workingDirectoryOptionBuilder,
        IVagrantBinPathOptionBuilder vagrantBinPathOptionBuilder
    ) : base(workingDirectoryOptionBuilder, timeoutMsOptionBuilder, vagrantBinPathOptionBuilder)
    {
        _command = command;
        _responseBuilderFactory = responseBuilderFactory;
        _namingPatternOptionBuilder = namingPatternOptionBuilder;
        _zeroesOptionBuilder = zeroesOptionBuilder;
    }

    public void Integrate(Command parentCommand)
    {
        Option<string> namingPatternOpt = _namingPatternOptionBuilder.Build();
        Option<int> zeroesOpt = _zeroesOptionBuilder.Build();
        Option<int> timeoutMsOpt = TimeoutMsOptionBuilder.Build();
        Option<string> workingDirOpt = WorkingDirectoryOptionBuilder.Build();

        var command = new Command("init", "Runs Vex init") {
            namingPatternOpt,
            zeroesOpt,
            timeoutMsOpt,
            workingDirOpt
        };

        var binder = new InitCommandIntegrationPayloadBinder(
            namingPatternOpt,
            zeroesOpt,
            timeoutMsOpt,
            workingDirOpt
        );

        command.SetHandler(async context =>
        {
            var payload = binder.GetBoundValue(context);
            var requestBuilder = _responseBuilderFactory.Factory();

            BuildBase(requestBuilder, payload);

            var request = requestBuilder
                    .WithNamingPattern(payload.Naming!)
                    .WithGivenLeadingZeroes(payload.Zeroes)
                    .Build()
                ;

            await _command.Execute(request);

            context.ExitCode = 0;
        });

        parentCommand.AddCommand(command);
    }
}