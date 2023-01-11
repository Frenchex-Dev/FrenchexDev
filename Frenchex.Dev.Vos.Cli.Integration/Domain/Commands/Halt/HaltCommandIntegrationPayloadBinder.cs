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

namespace Frenchex.Dev.Vos.Cli.Integration.Domain.Commands.Halt;

public class HaltCommandIntegrationPayloadBinder : IGenericBinder<HaltCommandIntegrationPayload>
{
    private readonly Option<bool> _force;
    private readonly Option<string> _haltTimeoutStr;
    private readonly Argument<string[]> _names;
    private readonly Option<string> _timeoutStr;
    private readonly Option<string> _vagrantBinPath;
    private readonly Option<string> _workingDirectory;

    public HaltCommandIntegrationPayloadBinder(
        Argument<string[]> names,
        Option<bool> force,
        Option<string> haltTimeoutStr,
        Option<string> timeoutStr,
        Option<string> workingDirectory,
        Option<string> vagrantBinPath
    )
    {
        _names = names;
        _force = force;
        _haltTimeoutStr = haltTimeoutStr;
        _timeoutStr = timeoutStr;
        _workingDirectory = workingDirectory;
        _vagrantBinPath = vagrantBinPath;
    }

    public HaltCommandIntegrationPayload GetBoundValue(InvocationContext invocationContext)
    {
        return new HaltCommandIntegrationPayload
        {
            Force = invocationContext.ParseResult.GetValueForOption(_force),
            HaltTimeout = invocationContext.ParseResult.GetValueForOption(_haltTimeoutStr),
            Names = invocationContext.ParseResult.GetValueForArgument(_names),
            TimeoutString = invocationContext.ParseResult.GetValueForOption(_timeoutStr),
            WorkingDirectory = invocationContext.ParseResult.GetValueForOption(_workingDirectory),
            VagrantBinPath = invocationContext.ParseResult.GetValueForOption(_vagrantBinPath)
        };
    }
}