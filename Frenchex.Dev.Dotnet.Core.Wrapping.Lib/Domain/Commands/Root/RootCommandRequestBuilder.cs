#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

namespace Frenchex.Dev.Dotnet.Wrapping.Lib.Domain.Commands.Root;

public abstract class RootCommandRequestBuilder : IRootCommandRequestBuilder
{
    protected RootCommandRequestBuilder(
        IBaseCommandRequestBuilderFactory? baseRequestBuilderFactory
    )
    {
        if (null == baseRequestBuilderFactory) throw new ArgumentNullException(nameof(baseRequestBuilderFactory));

        BaseBuilder = baseRequestBuilderFactory.Factory(this);
    }

    public IBaseCommandRequestBuilder BaseBuilder { get; }
}