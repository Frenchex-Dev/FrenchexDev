using Frenchex.Dev.Dotnet.Wrapping.Lib.Domain.Commands.Root;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Validate.Request;

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Validate.Request;

public class ValidateCommandRequest : IValidateCommandRequest
{
    public ValidateCommandRequest(IBaseCommandRequest @base)
    {
        Base = @base;
    }

    public IBaseCommandRequest Base { get; }
}