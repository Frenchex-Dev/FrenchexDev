#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Base.Request;

#endregion

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Root.Base.Request;

public class BaseRequestBuilderFactory : IBaseRequestBuilderFactory
{
    public IBaseRequestBuilder Factory(object parent)
    {
        return new BaseRequestBuilder().SetParent(parent);
    }
}