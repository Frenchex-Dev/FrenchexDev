#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using System.CommandLine;
using Frenchex.Dev.Vos.Cli.Integration.Domain.Options;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Init.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Init.Request;

#endregion

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
        ITimeoutMsOptionBuilder timeoutStrOptionBuilder,
        IWorkingDirectoryOptionBuilder workingDirectoryOptionBuilder,
        IVagrantBinPathOptionBuilder vagrantBinPathOptionBuilder
    ) : base(workingDirectoryOptionBuilder, timeoutStrOptionBuilder, vagrantBinPathOptionBuilder)
    {
        _command = command;
        _responseBuilderFactory = responseBuilderFactory;
        _namingPatternOptionBuilder = namingPatternOptionBuilder;
        _zeroesOptionBuilder = zeroesOptionBuilder;
    }

    public void IntegrateInto(Command parentCommand)
    {
        var namingPatternOpt = _namingPatternOptionBuilder.Build();
        var zeroesOpt = _zeroesOptionBuilder.Build();
        var timeoutStrOpt = TimeoutStrOptionBuilder.Build();
        var workingDirOpt = WorkingDirectoryOptionBuilder.Build();

        var command = new Command("init", "Runs Vex init")
        {
            namingPatternOpt,
            zeroesOpt,
            timeoutStrOpt,
            workingDirOpt
        };

        var binder = new InitCommandIntegrationPayloadBinder(
            namingPatternOpt,
            zeroesOpt,
            timeoutStrOpt,
            workingDirOpt
        );

        command.SetHandler(async context =>
        {
            InitCommandIntegrationPayload? payload = binder.GetBoundValue(context);
            IInitCommandRequestBuilder? requestBuilder = _responseBuilderFactory.Factory();

            BuildBase(requestBuilder, payload);

            IInitCommandRequest? request = requestBuilder
                    .WithNamingPattern(payload.Naming!)
                    .WithGivenLeadingZeroes(payload.Zeroes)
                    .Build()
                ;

            await _command.ExecuteAsync(request);

            context.ExitCode = 0;
        });

        parentCommand.AddCommand(command);
    }
}