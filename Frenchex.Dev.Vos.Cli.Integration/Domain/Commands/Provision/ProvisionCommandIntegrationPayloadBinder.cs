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

namespace Frenchex.Dev.Vos.Cli.Integration.Domain.Commands.Provision;

public class ProvisionCommandIntegrationPayloadBinder : IGenericBinder<ProvisionCommandIntegrationPayload>
{
    private readonly Argument<string[]> _names;
    private readonly Option<string[]> _provisionWith;
    private readonly Option<string> _timeout;
    private readonly Option<string> _vagrantBinPath;
    private readonly Option<string> _workingDir;

    public ProvisionCommandIntegrationPayloadBinder(
        Argument<string[]> names,
        Option<string[]> provisionWith,
        Option<string> timeout,
        Option<string> workingDir,
        Option<string> vagrantBinPath
    )
    {
        _names = names;
        _provisionWith = provisionWith;
        _timeout = timeout;
        _workingDir = workingDir;
        _vagrantBinPath = vagrantBinPath;
    }

    public ProvisionCommandIntegrationPayload GetBoundValue(InvocationContext bindingContext)
    {
        return new ProvisionCommandIntegrationPayload
        {
            Names = bindingContext.ParseResult.GetValueForArgument(_names),
            ProvisionWith = bindingContext.ParseResult.GetValueForOption(_provisionWith),
            TimeoutString = bindingContext.ParseResult.GetValueForOption(_timeout),
            WorkingDirectory = bindingContext.ParseResult.GetValueForOption(_workingDir),
            VagrantBinPath = bindingContext.ParseResult.GetValueForOption(_vagrantBinPath)
        };
    }
}