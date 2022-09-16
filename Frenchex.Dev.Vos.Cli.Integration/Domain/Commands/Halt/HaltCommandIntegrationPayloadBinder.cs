using System.CommandLine;
using System.CommandLine.Invocation;

namespace Frenchex.Dev.Vos.Cli.Integration.Domain.Commands.Halt;

public class HaltCommandIntegrationPayloadBinder : IGenericBinder<HaltCommandIntegrationPayload>
{
    private readonly Option<bool> _force;
    private readonly Option<int> _haltTimeoutMs;
    private readonly Argument<string[]> _names;
    private readonly Option<int> _timeoutMs;
    private readonly Option<string> _vagrantBinPath;
    private readonly Option<string> _workingDirectory;

    public HaltCommandIntegrationPayloadBinder(
        Argument<string[]> names,
        Option<bool> force,
        Option<int> haltTimeoutMs,
        Option<int> timeoutMs,
        Option<string> workingDirectory,
        Option<string> vagrantBinPath
    )
    {
        _names = names;
        _force = force;
        _haltTimeoutMs = haltTimeoutMs;
        _timeoutMs = timeoutMs;
        _workingDirectory = workingDirectory;
        _vagrantBinPath = vagrantBinPath;
    }

    public HaltCommandIntegrationPayload GetBoundValue(InvocationContext invocationContext)
    {
        return new HaltCommandIntegrationPayload {
            Force = invocationContext.ParseResult.GetValueForOption(_force),
            HaltTimeoutMs = invocationContext.ParseResult.GetValueForOption(_haltTimeoutMs),
            Names = invocationContext.ParseResult.GetValueForArgument(_names),
            TimeoutMs = invocationContext.ParseResult.GetValueForOption(_timeoutMs),
            WorkingDirectory = invocationContext.ParseResult.GetValueForOption(_workingDirectory),
            VagrantBinPath = invocationContext.ParseResult.GetValueForOption(_vagrantBinPath)
        };
    }
}