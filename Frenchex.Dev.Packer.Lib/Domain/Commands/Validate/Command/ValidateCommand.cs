using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Validate.Command;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Validate.Request;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Validate.Response;

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Validate.Command;

public class ValidateCommand : IValidateCommand
{
    public string GetCliCommandName()
    {
        return "validate";
    }


    public IValidateCommandResponse StartProcess(IValidateCommandRequest request)
    {
        throw new NotImplementedException();
    }
}