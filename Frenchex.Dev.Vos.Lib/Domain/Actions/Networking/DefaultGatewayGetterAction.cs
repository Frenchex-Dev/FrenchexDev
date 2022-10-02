using System.Net;
using System.Net.NetworkInformation;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Actions.Networking;

namespace Frenchex.Dev.Vos.Lib.Domain.Actions.Networking;

public class DefaultGatewayGetterAction : IDefaultGatewayGetterAction
{
    public List<(NetworkInterface n, List<IPAddress?>?)> GetDefaultGateway()
    {
        NetworkInterface[] interfaces = NetworkInterface
            .GetAllNetworkInterfaces();

        List<(NetworkInterface n, List<IPAddress?>?)> upAndNotLoopBackInterface = interfaces
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