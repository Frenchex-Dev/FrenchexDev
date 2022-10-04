using System.CommandLine;
using System.CommandLine.Invocation;

namespace Frenchex.Dev.Vos.Cli.Integration.Domain.Commands.Define.Machine.Add;

public class DefineMachineAddCommandIntegrationPayloadBinder : IGenericBinder<DefineMachineAddCommandIntegrationPayload>
{
    private readonly Argument<int> _instances;
    private readonly Option<string> _ipv4Pattern;
    private readonly Option<int> _ipv4Start;
    private readonly Option<bool> _isEnabled;
    private readonly Option<bool> _isPrimary;
    private readonly Argument<string> _name;
    private readonly Option<string> _namingPattern;
    private readonly Option<string> _networkBridge;
    private readonly Option<int> _ramMb;
    private readonly Option<string> _timeoutStr;
    private readonly Argument<string> _type;
    private readonly Option<string> _vagrantBinPath;
    private readonly Option<int> _vCpus;
    private readonly Option<string> _workingDir;

    public DefineMachineAddCommandIntegrationPayloadBinder(
        Argument<string> name,
        Argument<string> type,
        Argument<int> instances,
        Option<string> namingPattern,
        Option<bool> isPrimary,
        Option<bool> isEnabled,
        Option<int> vCpus,
        Option<int> ramMb,
        Option<string> ipv4Pattern,
        Option<int> ipv4Start,
        Option<string> networkBridge,
        Option<string> timeoutStr,
        Option<string> workingDir,
        Option<string> vagrantBinPath
    )
    {
        _name = name;
        _type = type;
        _instances = instances;
        _namingPattern = namingPattern;
        _isPrimary = isPrimary;
        _isEnabled = isEnabled;
        _vCpus = vCpus;
        _ramMb = ramMb;
        _ipv4Pattern = ipv4Pattern;
        _ipv4Start = ipv4Start;
        _networkBridge = networkBridge;
        _timeoutStr = timeoutStr;
        _workingDir = workingDir;
        _vagrantBinPath = vagrantBinPath;
    }

    public DefineMachineAddCommandIntegrationPayload GetBoundValue(InvocationContext invocationContext)
    {
        return new DefineMachineAddCommandIntegrationPayload {
            Type = invocationContext.ParseResult.GetValueForArgument(_type),
            RamInMb = invocationContext.ParseResult.GetValueForOption(_ramMb),
            Enabled = invocationContext.ParseResult.GetValueForOption(_isEnabled),
            IPv4Pattern = invocationContext.ParseResult.GetValueForOption(_ipv4Pattern),
            IPv4Start = invocationContext.ParseResult.GetValueForOption(_ipv4Start),
            Instances = invocationContext.ParseResult.GetValueForArgument(_instances),
            IsPrimary = invocationContext.ParseResult.GetValueForOption(_isPrimary),
            Name = invocationContext.ParseResult.GetValueForArgument(_name),
            NamingPattern = invocationContext.ParseResult.GetValueForOption(_namingPattern),
            NetworkBridge = invocationContext.ParseResult.GetValueForOption(_networkBridge),
            TimeoutString = invocationContext.ParseResult.GetValueForOption(_timeoutStr),
            VCpus = invocationContext.ParseResult.GetValueForOption(_vCpus),
            WorkingDirectory = invocationContext.ParseResult.GetValueForOption(_workingDir)
        };
    }
}