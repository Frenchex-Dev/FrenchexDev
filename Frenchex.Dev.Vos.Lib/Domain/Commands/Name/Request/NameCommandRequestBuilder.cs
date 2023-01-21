#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Name.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Base.Request;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Root.Request;

#endregion

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Name.Request;

public class NameCommandRequestBuilder : RootCommandRequestBuilder, INameCommandRequestBuilder
{
    private string[]? _names;

    public NameCommandRequestBuilder(IBaseRequestBuilderFactory baseRequestBuilderFactory) : base(
        baseRequestBuilderFactory)
    {
    }

    public INameCommandRequest Build()
    {
        if (null == _names) throw new InvalidOperationException("Names is null");

        return new NameCommandCommandRequest(
            BaseBuilder.Build(),
            _names
        );
    }

    public INameCommandRequestBuilder WithNames(string[] names)
    {
        _names = names;
        return this;
    }
}