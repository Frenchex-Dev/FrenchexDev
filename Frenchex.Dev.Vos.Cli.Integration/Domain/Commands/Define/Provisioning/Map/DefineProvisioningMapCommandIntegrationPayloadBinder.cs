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

namespace Frenchex.Dev.Vos.Cli.Integration.Domain.Commands.Define.Provisioning.Map;

public class
    DefineProvisioningMapCommandIntegrationPayloadBinder : IGenericBinder<
        DefineProvisioningMapCommandIntegrationPayload>
{
    private readonly Option<bool> _isEnabled;
    private readonly Argument<string> _machineName;
    private readonly Option<bool> _machineType;
    private readonly Option<bool> _privileged;
    private readonly Argument<string> _provision;
    private readonly Option<string> _timeoutStr;
    private readonly Argument<string> _version;
    private readonly Option<string> _workingDir;

    public DefineProvisioningMapCommandIntegrationPayloadBinder(
        Argument<string> machineName,
        Argument<string> provision,
        Argument<string> version,
        Option<bool> privileged,
        Option<bool> isEnabled,
        Option<bool> machineType,
        Option<string> timeoutStr,
        Option<string> workingDir
    )
    {
        _machineName = machineName;
        _provision = provision;
        _version = version;
        _privileged = privileged;
        _isEnabled = isEnabled;
        _machineType = machineType;
        _timeoutStr = timeoutStr;
        _workingDir = workingDir;
    }

    public DefineProvisioningMapCommandIntegrationPayload GetBoundValue(InvocationContext invocationContext)
    {
        return new DefineProvisioningMapCommandIntegrationPayload
        {
            TimeoutString = invocationContext.ParseResult.GetValueForOption(_timeoutStr),
            WorkingDirectory = invocationContext.ParseResult.GetValueForOption(_workingDir),
            Provision = invocationContext.ParseResult.GetValueForArgument(_provision),
            MachineType = invocationContext.ParseResult.GetValueForOption(_machineType),
            MachineName = invocationContext.ParseResult.GetValueForArgument(_machineName),
            Enable = invocationContext.ParseResult.GetValueForOption(_isEnabled),
            Version = invocationContext.ParseResult.GetValueForArgument(_version),
            Privileged = invocationContext.ParseResult.GetValueForOption(_privileged),
            VagrantBinPath = "vagrant"
        };
    }
}