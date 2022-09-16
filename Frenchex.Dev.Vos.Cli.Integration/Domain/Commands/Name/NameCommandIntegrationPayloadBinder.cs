using System.CommandLine;
using System.CommandLine.Invocation;

namespace Frenchex.Dev.Vos.Cli.Integration.Domain.Commands.Name;

public class NameCommandIntegrationPayloadBinder : IGenericBinder<NameCommandIntegrationPayload>
{
    private readonly Argument<string[]> _nameArg;
    private readonly Option<int> _timeoutOpt;
    private readonly Option<string> _workingDirOpt;

    public NameCommandIntegrationPayloadBinder(
        Argument<string[]> nameArg,
        Option<int> timeoutOpt,
        Option<string> workingDirOpt
    )
    {
        _nameArg = nameArg;
        _workingDirOpt = workingDirOpt;
        _timeoutOpt = timeoutOpt;
    }

    public NameCommandIntegrationPayload GetBoundValue(InvocationContext invocationContext)
    {
        return new NameCommandIntegrationPayload {
            WorkingDirectory = invocationContext.ParseResult.GetValueForOption(_workingDirOpt),
            TimeoutMs = invocationContext.ParseResult.GetValueForOption(_timeoutOpt),
            Names = invocationContext.ParseResult.GetValueForArgument(_nameArg)
        };
    }
}