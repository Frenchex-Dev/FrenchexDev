using System.CommandLine;
using System.CommandLine.Invocation;

namespace Frenchex.Dev.Vos.Cli.Integration.Domain.Commands.Destroy;

public class DestroyCommandIntegrationPayloadBinder : IGenericBinder<DestroyCommandIntegrationPayload>
{
    private readonly Option<bool> _forceOpt;
    private readonly Option<bool> _gracefulOpt;
    private readonly Argument<string[]> _nameOpt;
    private readonly Option<int> _timeoutMsOpt;
    private readonly Option<string> _vagrantBinPath;
    private readonly Option<string> _workingDirOpt;

    public DestroyCommandIntegrationPayloadBinder(
        Argument<string[]> nameOpt,
        Option<bool> forceOpt,
        Option<bool> gracefulOpt,
        Option<int> timeoutMsOpt,
        Option<string> workingDirOpt,
        Option<string> vagrantBinPath
    )
    {
        _nameOpt = nameOpt;
        _forceOpt = forceOpt;
        _gracefulOpt = gracefulOpt;
        _timeoutMsOpt = timeoutMsOpt;
        _workingDirOpt = workingDirOpt;
        _vagrantBinPath = vagrantBinPath;
    }

    public DestroyCommandIntegrationPayload GetBoundValue(InvocationContext invocationContext)
    {
        return new DestroyCommandIntegrationPayload {
            Force = invocationContext.ParseResult.GetValueForOption(_forceOpt),
            Graceful = invocationContext.ParseResult.GetValueForOption(_gracefulOpt),
            NameOrId = invocationContext.ParseResult.GetValueForArgument(_nameOpt),
            TimeoutMs = invocationContext.ParseResult.GetValueForOption(_timeoutMsOpt),
            WorkingDirectory = invocationContext.ParseResult.GetValueForOption(_workingDirOpt),
            VagrantBinPath = invocationContext.ParseResult.GetValueForOption(_vagrantBinPath)
        };
    }
}