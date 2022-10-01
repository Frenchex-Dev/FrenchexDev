using Frenchex.Dev.Dotnet.Core.Process.Lib.Domain.Process;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Validate.Response;

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Validate.Response;

public class ValidateCommandResponse : IValidateCommandResponse
{
    public ValidateCommandResponse(IProcess process, ProcessExecutionResult processExecutionResult)
    {
        Process = process;
        ProcessExecutionResult = processExecutionResult;
    }

    public IProcess Process { get; }
    public ProcessExecutionResult ProcessExecutionResult { get; }
}