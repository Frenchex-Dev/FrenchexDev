using Frenchex.Dev.Vos.Web.Api.Server.Bases;

namespace Frenchex.Dev.Vos.Web.Api.Server.Controllers.Define.Provisioning.Map;

public interface IDefineProvisioningMapAsyncHandler : IAsyncHandler<DefineProvisioningMapRequest,
    DefineProvisioningMapResponse, DefineProvisioningMapError>
{

}