#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Request;

#endregion

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Halt.Request;

public interface IHaltCommandRequestBuilderFactory : IRootCommandRequestBuilderFactory
{
    IHaltCommandRequestBuilder Factory();
}