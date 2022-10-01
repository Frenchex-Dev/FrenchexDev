using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Build.Command;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Build.Request;

namespace Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Build.Facade;

public interface
    IBuildCommandFacade : IFacade<IBuildCommand, IBuildCommandRequestBuilderFactory, IBuildCommandRequestBuilder>
{
}