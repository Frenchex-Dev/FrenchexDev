using System.CommandLine;
using System.CommandLine.Invocation;

namespace Frenchex.Dev.Vos.Cli.Integration.Domain.Commands.Status;

public class StatusCommandIntegrationPayloadBinder : IGenericBinder<StatusCommandIntegrationPayload>
{
    private readonly Argument<string[]> _nameArg;
    private readonly Option<int> _timeoutOpt;
    private readonly Option<string> _workingDirOpt;

    public StatusCommandIntegrationPayloadBinder(
        Argument<string[]> nameArg,
        Option<string> workingDirOpt,
        Option<int> timeoutOpt
    )
    {
        _nameArg = nameArg;
        _workingDirOpt = workingDirOpt;
        _timeoutOpt = timeoutOpt;
    }

    public StatusCommandIntegrationPayload GetBoundValue(InvocationContext bindingContext)
    {
        return new StatusCommandIntegrationPayload {
            WorkingDirectory = bindingContext.ParseResult.GetValueForOption(_workingDirOpt),
            TimeoutMs = bindingContext.ParseResult.GetValueForOption(_timeoutOpt),
            Names = bindingContext.ParseResult.GetValueForArgument(_nameArg)
        };
    }
}