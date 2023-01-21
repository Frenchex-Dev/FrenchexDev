#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Root.Request;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Halt.Request;

public interface IHaltCommandRequestBuilder : IRootCommandRequestBuilder
{
    IHaltCommandRequest Build();
    IHaltCommandRequestBuilder UsingNamesOrIds(string[] namesOrIds);
    IHaltCommandRequestBuilder UsingHaltTimeout(string? timeout);
    IHaltCommandRequestBuilder WithForce(bool with);
}