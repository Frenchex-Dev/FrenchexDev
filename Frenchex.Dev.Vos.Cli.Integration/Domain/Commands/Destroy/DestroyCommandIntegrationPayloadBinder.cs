using System.CommandLine;
using System.CommandLine.Invocation;

namespace Frenchex.Dev.Vos.Cli.Integration.Domain.Commands.Destroy;

public class DestroyCommandIntegrationPayloadBinder : IGenericBinder<DestroyCommandIntegrationPayload>
{
    private readonly Option<bool> _forceOpt;
    private readonly Option<bool> _gracefulOpt;
    private readonly Argument<string[]> _nameOpt;
    private readonly Option<string> _timeoutStrOpt;
    private readonly Option<string> _vagrantBinPath;
    private readonly Option<string> _workingDirOpt;

    public DestroyCommandIntegrationPayloadBinder(
        Argument<string[]> nameOpt,
        Option<bool> forceOpt,
        Option<bool> gracefulOpt,
        Option<string> timeoutStrOpt,
        Option<string> workingDirOpt,
        Option<string> vagrantBinPath
    )
    {
        _nameOpt = nameOpt;
        _forceOpt = forceOpt;
        _gracefulOpt = gracefulOpt;
        _timeoutStrOpt = timeoutStrOpt;
        _workingDirOpt = workingDirOpt;
        _vagrantBinPath = vagrantBinPath;
    }

    public DestroyCommandIntegrationPayload GetBoundValue(InvocationContext invocationContext)
    {
        return new DestroyCommandIntegrationPayload {
            Force = invocationContext.ParseResult.GetValueForOption(_forceOpt),
            Graceful = invocationContext.ParseResult.GetValueForOption(_gracefulOpt),
            NameOrId = invocationContext.ParseResult.GetValueForArgument(_nameOpt),
            TimeoutString = invocationContext.ParseResult.GetValueForOption(_timeoutStrOpt),
            WorkingDirectory = invocationContext.ParseResult.GetValueForOption(_workingDirOpt),
            VagrantBinPath = invocationContext.ParseResult.GetValueForOption(_vagrantBinPath)
        };
    }
}