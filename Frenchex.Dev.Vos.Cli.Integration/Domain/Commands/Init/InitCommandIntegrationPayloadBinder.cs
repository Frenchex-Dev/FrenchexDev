using System.CommandLine;
using System.CommandLine.Invocation;

namespace Frenchex.Dev.Vos.Cli.Integration.Domain.Commands.Init;

public class InitCommandIntegrationPayloadBinder : IGenericBinder<InitCommandIntegrationPayload>
{
    private readonly Option<string> _nameOpt;
    private readonly Option<int> _timeoutMsOpt;
    private readonly Option<string> _workingDirOpt;
    private readonly Option<int> _zeroesOpt;

    public InitCommandIntegrationPayloadBinder(
        Option<string> nameOpt,
        Option<int> zeroesOpt,
        Option<int> timeoutMsOpt,
        Option<string> workingDirOpt
    )
    {
        _nameOpt = nameOpt;
        _zeroesOpt = zeroesOpt;
        _timeoutMsOpt = timeoutMsOpt;
        _workingDirOpt = workingDirOpt;
    }

    public InitCommandIntegrationPayload GetBoundValue(InvocationContext invocationContext)
    {
        return new InitCommandIntegrationPayload {
            Naming = invocationContext.ParseResult.GetValueForOption(_nameOpt)!,
            TimeoutMs = invocationContext.ParseResult.GetValueForOption(_timeoutMsOpt),
            WorkingDirectory = invocationContext.ParseResult.GetValueForOption(_workingDirOpt),
            Zeroes = invocationContext.ParseResult.GetValueForOption(_zeroesOpt)
        };
    }
}