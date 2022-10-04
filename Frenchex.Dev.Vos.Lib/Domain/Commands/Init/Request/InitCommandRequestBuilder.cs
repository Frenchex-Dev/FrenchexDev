using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Init.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Base.Request;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Root.Request;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Init.Request;

public class InitCommandRequestBuilder : RootCommandRequestBuilder, IInitCommandRequestBuilder
{
    private int? _leadingZeroes;

    private string? _namingPattern;

    public InitCommandRequestBuilder(IBaseRequestBuilderFactory baseRequestBuilderFactory) : base(
        baseRequestBuilderFactory)
    {
    }

    public IInitCommandRequest Build()
    {
        return new InitCommandCommandRequest(
            BaseBuilder.Build(),
            _namingPattern ?? "",
            _leadingZeroes ?? 1
        );
    }

    public IInitCommandRequestBuilder WithGivenLeadingZeroes(int leadingZeroes)
    {
        _leadingZeroes = leadingZeroes;
        return this;
    }

    public IInitCommandRequestBuilder WithNamingPattern(string namingPattern)
    {
        _namingPattern = namingPattern;
        return this;
    }
}