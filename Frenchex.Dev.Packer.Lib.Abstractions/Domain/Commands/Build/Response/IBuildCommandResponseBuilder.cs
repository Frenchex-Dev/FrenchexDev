using Frenchex.Dev.Dotnet.Core.Wrapping.Lib.Abstractions.Domain.Commands.Root.Response;
using Frenchex.Dev.Dotnet.Wrapping.Lib.Domain.Commands.Root;

namespace Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Build.Response;

public interface IBuildCommandResponseBuilder : IRootCommandResponseBuilder
{
    IBuildCommandResponse Build();
}