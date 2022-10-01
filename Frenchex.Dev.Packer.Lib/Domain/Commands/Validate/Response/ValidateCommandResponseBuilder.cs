using Frenchex.Dev.Dotnet.Core.Process.Lib.Domain.Process;
using Frenchex.Dev.Dotnet.Wrapping.Lib.Domain.Commands.Root;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Validate.Response;

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Validate.Response;

public class ValidateCommandResponseBuilder : IValidateCommandResponseBuilder
{
    public IRootCommandResponseBuilder SetProcess(IProcess process)
    {
        throw new NotImplementedException();
    }

    public IRootCommandResponseBuilder SetProcessExecutionResult(ProcessExecutionResult processExecutionResult)
    {
        throw new NotImplementedException();
    }

    public IValidateCommandResponse Build()
    {
        throw new NotImplementedException();
    }
}