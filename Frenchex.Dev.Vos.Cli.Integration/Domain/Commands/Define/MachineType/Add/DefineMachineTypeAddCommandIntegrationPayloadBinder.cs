using System.CommandLine;
using System.CommandLine.Invocation;

namespace Frenchex.Dev.Vos.Cli.Integration.Domain.Commands.Define.MachineType.Add;

public class
    DefineMachineTypeAddCommandIntegrationPayloadBinder : IGenericBinder<DefineMachineTypeAddCommandIntegrationPayload>
{
    private readonly Argument<string> _boxName;
    private readonly Option<bool> _is3DEnabled;
    private readonly Option<bool> _isEnabled;
    private readonly Argument<string> _name;
    private readonly Argument<string> _osType;
    private readonly Argument<string> _osVersion;
    private readonly Argument<int> _ramMb;
    private readonly Option<string> _timeoutStr;
    private readonly Argument<int> _vCpus;
    private readonly Option<int> _videoRamMb;
    private readonly Option<string> _workingDir;

    public DefineMachineTypeAddCommandIntegrationPayloadBinder(
        Argument<string> name,
        Argument<string> boxName,
        Argument<int> vCpus,
        Argument<int> ramMb,
        Argument<string> osType,
        Argument<string> osVersion,
        Option<bool> isEnabled,
        Option<bool> is3DEnabled,
        Option<int> videoRamMb,
        Option<string> timeoutStr,
        Option<string> workingDir
    )
    {
        _name = name;
        _boxName = boxName;
        _isEnabled = isEnabled;
        _is3DEnabled = is3DEnabled;
        _videoRamMb = videoRamMb;
        _vCpus = vCpus;
        _ramMb = ramMb;
        _osType = osType;
        _osVersion = osVersion;
        _timeoutStr = timeoutStr;
        _workingDir = workingDir;
    }

    public DefineMachineTypeAddCommandIntegrationPayload GetBoundValue(InvocationContext invocationContext)
    {
        return new DefineMachineTypeAddCommandIntegrationPayload {
            BoxName = invocationContext.ParseResult.GetValueForArgument(_boxName),
            RamInMb = invocationContext.ParseResult.GetValueForArgument(_ramMb),
            Enabled = invocationContext.ParseResult.GetValueForOption(_isEnabled),
            Name = invocationContext.ParseResult.GetValueForArgument(_name),
            VCpus = invocationContext.ParseResult.GetValueForArgument(_vCpus),
            Enable3D = invocationContext.ParseResult.GetValueForOption(_is3DEnabled),
            VideoRamInMb = invocationContext.ParseResult.GetValueForOption(_videoRamMb),
            TimeoutString = invocationContext.ParseResult.GetValueForOption(_timeoutStr),
            OsType = invocationContext.ParseResult.GetValueForArgument(_osType),
            OsVersion = invocationContext.ParseResult.GetValueForArgument(_osVersion),
            WorkingDirectory = invocationContext.ParseResult.GetValueForOption(_workingDir)
        };
    }
}