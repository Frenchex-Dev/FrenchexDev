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

namespace Frenchex.Dev.Vos.Cli.Integration.Domain.Commands.Name;

public class NameCommandIntegrationPayloadBinder : IGenericBinder<NameCommandIntegrationPayload>
{
    private readonly Argument<string[]> _nameArg;
    private readonly Option<string> _timeoutOpt;
    private readonly Option<string> _workingDirOpt;

    public NameCommandIntegrationPayloadBinder(
        Argument<string[]> nameArg,
        Option<string> timeoutOpt,
        Option<string> workingDirOpt
    )
    {
        _nameArg = nameArg;
        _workingDirOpt = workingDirOpt;
        _timeoutOpt = timeoutOpt;
    }

    public NameCommandIntegrationPayload GetBoundValue(InvocationContext invocationContext)
    {
        return new NameCommandIntegrationPayload
        {
            WorkingDirectory = invocationContext.ParseResult.GetValueForOption(_workingDirOpt),
            TimeoutString = invocationContext.ParseResult.GetValueForOption(_timeoutOpt),
            Names = invocationContext.ParseResult.GetValueForArgument(_nameArg)
        };
    }
}