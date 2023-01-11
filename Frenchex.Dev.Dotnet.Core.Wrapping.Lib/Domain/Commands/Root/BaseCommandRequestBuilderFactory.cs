#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

namespace Frenchex.Dev.Dotnet.Wrapping.Lib.Domain.Commands.Root;

public class BaseCommandRequestBuilderFactory : IBaseCommandRequestBuilderFactory
{
    public IBaseCommandRequestBuilder Factory(object parent)
    {
        return new BaseCommandRequestBuilder(parent);
    }
}