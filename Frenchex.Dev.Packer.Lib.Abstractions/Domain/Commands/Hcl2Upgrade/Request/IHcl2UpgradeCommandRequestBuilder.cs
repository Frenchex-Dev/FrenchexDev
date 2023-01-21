#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Dotnet.Wrapping.Lib.Domain.Commands.Root;

#endregion

namespace Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Hcl2Upgrade.Request;

public interface IHcl2UpgradeCommandRequestBuilder : IRootCommandRequestBuilder
{
    IHcl2UpgradeCommandRequest Build();
}