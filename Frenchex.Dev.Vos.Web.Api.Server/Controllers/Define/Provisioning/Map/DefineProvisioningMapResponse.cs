using Frenchex.Dev.Vos.Web.Api.Server.Bases;

namespace Frenchex.Dev.Vos.Web.Api.Server.Controllers.Define.Provisioning.Map;

public class DefineProvisioningMapResponse : IResponse<DefineProvisioningMapError>
{
    public bool IsSuccess { get; set; }
    public List<DefineProvisioningMapError> Errors { get; set; }
}