#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using System.CommandLine;
using System.CommandLine.Invocation;

#endregion

namespace Frenchex.Dev.Vos.Cli.Integration.Domain.Commands.Status;

public class StatusCommandIntegrationPayloadBinder : IGenericBinder<StatusCommandIntegrationPayload>
{
    private readonly Argument<string[]> _nameArg;
    private readonly Option<string> _timeoutOpt;
    private readonly Option<string> _workingDirOpt;

    public StatusCommandIntegrationPayloadBinder(
        Argument<string[]> nameArg,
        Option<string> workingDirOpt,
        Option<string> timeoutOpt
    )
    {
        _nameArg = nameArg;
        _workingDirOpt = workingDirOpt;
        _timeoutOpt = timeoutOpt;
    }

    public StatusCommandIntegrationPayload GetBoundValue(InvocationContext bindingContext)
    {
        return new StatusCommandIntegrationPayload
        {
            WorkingDirectory = bindingContext.ParseResult.GetValueForOption(_workingDirOpt),
            TimeoutString = bindingContext.ParseResult.GetValueForOption(_timeoutOpt),
            Names = bindingContext.ParseResult.GetValueForArgument(_nameArg)
        };
    }
}