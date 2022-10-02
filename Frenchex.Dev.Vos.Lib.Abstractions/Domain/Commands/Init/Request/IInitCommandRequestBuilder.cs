using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Init.Request;

public interface IInitCommandRequestBuilder : IRootCommandRequestBuilder
{
    IInitCommandRequest Build();
    IInitCommandRequestBuilder WithNamingPattern(string namingPattern);
    IInitCommandRequestBuilder WithGivenLeadingZeroes(int leadingZeroes);
}