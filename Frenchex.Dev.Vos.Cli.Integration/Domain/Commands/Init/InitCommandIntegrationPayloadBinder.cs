#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using System.CommandLine;
using System.CommandLine.Invocation;

#endregion

namespace Frenchex.Dev.Vos.Cli.Integration.Domain.Commands.Init;

public class InitCommandIntegrationPayloadBinder : IGenericBinder<InitCommandIntegrationPayload>
{
    private readonly Option<string> _nameOpt;
    private readonly Option<string> _timeoutStrOpt;
    private readonly Option<string> _workingDirOpt;
    private readonly Option<int> _zeroesOpt;

    public InitCommandIntegrationPayloadBinder(
        Option<string> nameOpt,
        Option<int> zeroesOpt,
        Option<string> timeoutStrOpt,
        Option<string> workingDirOpt
    )
    {
        _nameOpt = nameOpt;
        _zeroesOpt = zeroesOpt;
        _timeoutStrOpt = timeoutStrOpt;
        _workingDirOpt = workingDirOpt;
    }

    public InitCommandIntegrationPayload GetBoundValue(InvocationContext invocationContext)
    {
        return new InitCommandIntegrationPayload
        {
            Naming = invocationContext.ParseResult.GetValueForOption(_nameOpt)!,
            TimeoutString = invocationContext.ParseResult.GetValueForOption(_timeoutStrOpt),
            WorkingDirectory = invocationContext.ParseResult.GetValueForOption(_workingDirOpt),
            Zeroes = invocationContext.ParseResult.GetValueForOption(_zeroesOpt)
        };
    }
}