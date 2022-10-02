using System.Net;
using System.Net.NetworkInformation;

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Actions.Networking;

public interface IDefaultGatewayGetterAction
{
    List<(NetworkInterface n, List<IPAddress?>?)> GetDefaultGateway();
}