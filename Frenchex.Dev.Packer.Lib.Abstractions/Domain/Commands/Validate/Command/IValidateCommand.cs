using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Validate.Request;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Validate.Response;

namespace Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Validate.Command;

public interface IValidateCommand : IFacableCommand,
    ICommand<IValidateCommandRequest, IValidateCommandResponse>
{
}