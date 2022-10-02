using System.CommandLine;
using System.CommandLine.Invocation;

namespace Frenchex.Dev.Vos.Cli.Integration.Domain.Commands.Ssh;

public class SshCommandIntegrationPayloadBinder : IGenericBinder<SshCommandIntegrationPayload>
{
    private readonly Option<string[]> _commandsOpt;
    private readonly Option<string> _extraSshArgsOpt;
    private readonly Option<string[]> _namesOpts;
    private readonly Option<bool> _plainTextOpt;
    private readonly Option<string> _timeOutStrOpt;
    private readonly Option<string> _vagrantBinPath;
    private readonly Option<string> _workingDir;

    public SshCommandIntegrationPayloadBinder(
        Option<string[]> namesOpts,
        Option<string[]> commandsOpt,
        Option<string> timeOutStrOpt,
        Option<string> vagrantBinPath,
        Option<string> workingDir,
        Option<bool> plainTextOpt,
        Option<string> extraSshArgsOpt
    )
    {
        _namesOpts = namesOpts;
        _commandsOpt = commandsOpt;
        _timeOutStrOpt = timeOutStrOpt;
        _vagrantBinPath = vagrantBinPath;
        _workingDir = workingDir;
        _plainTextOpt = plainTextOpt;
        _extraSshArgsOpt = extraSshArgsOpt;
    }

    public SshCommandIntegrationPayload GetBoundValue(InvocationContext invocationContext)
    {
        return new SshCommandIntegrationPayload {
            Commands = invocationContext.ParseResult.GetValueForOption(_commandsOpt),
            NamesOrIds = invocationContext.ParseResult.GetValueForOption(_namesOpts),
            TimeoutString = invocationContext.ParseResult.GetValueForOption(_timeOutStrOpt),
            WorkingDirectory = invocationContext.ParseResult.GetValueForOption(_workingDir),
            VagrantBinPath = invocationContext.ParseResult.GetValueForOption(_vagrantBinPath),
            Plain = invocationContext.ParseResult.GetValueForOption(_plainTextOpt),
            ExtraSshArgs = invocationContext.ParseResult.GetValueForOption(_extraSshArgsOpt)
        };
    }
}