#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using System.CommandLine;
using System.CommandLine.Invocation;

#endregion

namespace Frenchex.Dev.Vos.Cli.Integration.Domain.Commands.SshConfig;

public class SshConfigCommandIntegrationPayloadBinder : IGenericBinder<SshConfigCommandIntegrationPayload>
{
    private readonly Option<string> _extraSshArgsOpt;
    private readonly Argument<string[]> _namesOrIdsArg;
    private readonly Option<bool> _plainTextOpt;
    private readonly Option<string> _timeOutMsOpt;
    private readonly Option<string> _vagrantBinPathOpt;
    private readonly Option<bool> _withColor;
    private readonly Option<string> _workingDirOpt;

    public SshConfigCommandIntegrationPayloadBinder(
        Argument<string[]> namesOrIdsArg,
        Option<string> workingDirOpt,
        Option<string> timeOutMsOpt,
        Option<string> vagrantBinPathOpt,
        Option<bool> plainTextOpt,
        Option<string> extraSshArgsOpt,
        Option<bool> withColor
    )
    {
        _namesOrIdsArg = namesOrIdsArg;
        _timeOutMsOpt = timeOutMsOpt;
        _vagrantBinPathOpt = vagrantBinPathOpt;
        _plainTextOpt = plainTextOpt;
        _extraSshArgsOpt = extraSshArgsOpt;
        _withColor = withColor;
        _workingDirOpt = workingDirOpt;
        _vagrantBinPathOpt = vagrantBinPathOpt;
    }

    public SshConfigCommandIntegrationPayload GetBoundValue(InvocationContext invocationContext)
    {
        return new SshConfigCommandIntegrationPayload
        {
            NamesOrIds = invocationContext.ParseResult.GetValueForArgument(_namesOrIdsArg),
            TimeoutString = invocationContext.ParseResult.GetValueForOption(_timeOutMsOpt),
            WorkingDirectory = invocationContext.ParseResult.GetValueForOption(_workingDirOpt),
            VagrantBinPath = invocationContext.ParseResult.GetValueForOption(_vagrantBinPathOpt),
            Plain = invocationContext.ParseResult.GetValueForOption(_plainTextOpt),
            ExtraSshArgs = invocationContext.ParseResult.GetValueForOption(_extraSshArgsOpt),
            WithColor = invocationContext.ParseResult.GetValueForOption(_withColor)
        };
    }
}