using Frenchex.Dev.Dotnet.Wrapping.Lib.Domain.Commands.Root;

namespace Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Build.Response;

public interface IBuildCommandResponseBuilderFactory : IRootCommandResponseBuilderFactory
{
    IBuildCommandResponseBuilder Factory();
}