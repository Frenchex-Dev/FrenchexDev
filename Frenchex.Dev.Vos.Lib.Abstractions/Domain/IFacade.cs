#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Request;

#endregion

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain;

public interface IFacade<out TR1, out TR2, out TR3>
    where TR1 : IAsyncCommand
    where TR2 : IRootCommandRequestBuilderFactory
    where TR3 : IRootCommandRequestBuilder
{
    TR1 Command { get; }
    TR2 RequestBuilderFactory { get; }
    TR3 RequestBuilder { get; }
}