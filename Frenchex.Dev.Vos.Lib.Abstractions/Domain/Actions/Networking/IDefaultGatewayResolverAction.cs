#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using System.Net;
using System.Net.NetworkInformation;

#endregion

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Actions.Networking;

public interface IDefaultGatewayResolverAction
{
    List<(NetworkInterface n, List<IPAddress?>?)> ResolveDefaultGateway();
}