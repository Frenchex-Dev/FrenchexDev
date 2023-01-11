#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Base.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Status.Request;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Root.Request;

#endregion

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Status.Request;

public class StatusCommandRequestBuilderFactory : RootCommandRequestBuilderFactory, IStatusCommandRequestBuilderFactory
{
    public StatusCommandRequestBuilderFactory(IBaseRequestBuilderFactory baseRequestBuilderFactory) : base(
        baseRequestBuilderFactory)
    {
    }

    public IStatusCommandRequestBuilder Factory()
    {
        return new StatusCommandRequestBuilder(BaseRequestBuilderFactory);
    }
}