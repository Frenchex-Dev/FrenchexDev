#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using System.Net;
using System.Net.NetworkInformation;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Actions.Networking;

#endregion

namespace Frenchex.Dev.Vos.Lib.Domain.Actions.Networking;

public class DefaultGatewayResolverAction : IDefaultGatewayResolverAction
{
    public List<(NetworkInterface n, List<IPAddress?>?)> ResolveDefaultGateway()
    {
        var interfaces = NetworkInterface
            .GetAllNetworkInterfaces();

        var upAndNotLoopBackInterface = interfaces
            .Where(n => n.OperationalStatus == OperationalStatus.Up)
            .Where(n => n.NetworkInterfaceType != NetworkInterfaceType.Loopback)
            // ReSharper disable ConstantConditionalAccessQualifier
            .Select(n => (n, n.GetIPProperties()?.GatewayAddresses.Select(x => x?.Address).ToList()))
            // ReSharper restore ConstantConditionalAccessQualifier
            .Where(x => x.Item2 != null && x.Item2.Any())
            .ToList();

        return upAndNotLoopBackInterface;
    }
}