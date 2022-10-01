using Frenchex.Dev.Dotnet.Wrapping.Lib.Domain.Commands.Root;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Validate.Request;

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Validate.Request;

public class ValidateCommandRequestBuilder : IValidateCommandRequestBuilder
{
    public ValidateCommandRequestBuilder(IBaseCommandRequestBuilderFactory baseBuilderFactory)
    {
        BaseBuilder = baseBuilderFactory.Factory(this);
    }

    public IBaseCommandRequestBuilder BaseBuilder { get; }

    public IValidateCommandRequest Build()
    {
        throw new NotImplementedException();
    }
}