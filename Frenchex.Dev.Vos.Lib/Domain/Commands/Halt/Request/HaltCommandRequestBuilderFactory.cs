#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Halt.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Base.Request;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Root.Request;

#endregion

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Halt.Request;

public class HaltCommandRequestBuilderFactory : RootCommandRequestBuilderFactory, IHaltCommandRequestBuilderFactory
{
    public HaltCommandRequestBuilderFactory(IBaseRequestBuilderFactory baseRequestBuilderFactory) : base(
        baseRequestBuilderFactory)
    {
    }

    public IHaltCommandRequestBuilder Factory()
    {
        return new HaltCommandRequestBuilder(BaseRequestBuilderFactory);
    }
}