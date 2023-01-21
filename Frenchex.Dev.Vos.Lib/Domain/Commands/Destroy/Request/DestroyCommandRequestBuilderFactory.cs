#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Destroy.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Base.Request;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Root.Request;

#endregion

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Destroy.Request;

public class DestroyCommandRequestBuilderFactory : RootCommandRequestBuilderFactory,
    IDestroyCommandRequestBuilderFactory
{
    public DestroyCommandRequestBuilderFactory(IBaseRequestBuilderFactory baseRequestBuilderFactory) : base(
        baseRequestBuilderFactory)
    {
    }

    public IDestroyCommandRequestBuilder Factory()
    {
        return new DestroyCommandRequestBuilder(BaseRequestBuilderFactory);
    }
}