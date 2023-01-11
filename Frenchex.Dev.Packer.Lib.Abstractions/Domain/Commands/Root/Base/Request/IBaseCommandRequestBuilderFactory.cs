#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

namespace Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Root.Base.Request;

public interface IBaseCommandRequestBuilderFactory
{
    IBaseCommandRequestBuilder Factory(object parent);
}