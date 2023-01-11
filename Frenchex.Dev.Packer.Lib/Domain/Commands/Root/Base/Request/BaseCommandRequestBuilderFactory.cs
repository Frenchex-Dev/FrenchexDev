#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Root.Base.Request;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Root.Request;

#endregion

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Root.Base.Request;

public class BaseCommandRequestBuilderFactory : IRootCommandRequestBuilderFactory
{
    public IBaseCommandRequestBuilder Factory(object parent)
    {
        return new BaseCommandRequestBuilder(parent);
    }
}