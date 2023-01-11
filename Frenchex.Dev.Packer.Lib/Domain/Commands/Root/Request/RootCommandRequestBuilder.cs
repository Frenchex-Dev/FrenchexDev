#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Dotnet.Wrapping.Lib.Domain.Commands.Root;

#endregion

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Root.Request;

public abstract class RootCommandRequestBuilder : IRootCommandRequestBuilderFactory
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