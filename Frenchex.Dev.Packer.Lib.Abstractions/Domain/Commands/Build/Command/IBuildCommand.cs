using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Build.Request;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Build.Response;

namespace Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Build.Command;

public interface IBuildCommand : IFacableCommand, ICommand<IBuildCommandRequest, IBuildCommandResponse>
{
}