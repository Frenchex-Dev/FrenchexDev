#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Request;

#endregion

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Provision.Request;

public interface IProvisionCommandRequestBuilder : IRootCommandRequestBuilder
{
    IProvisionCommandRequest Build();
    IProvisionCommandRequestBuilder UsingNames(string[] names);
    IProvisionCommandRequestBuilder UsingProvisionWith(string[] provisionWith);
    IProvisionCommandRequestBuilder Enable();
    IProvisionCommandRequestBuilder Disable();
}