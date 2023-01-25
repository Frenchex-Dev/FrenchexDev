using Frenchex.Dev.Vos.Lib.Domain.Commands.Define.Provisioning.Map.Request;
using Frenchex.Dev.Vos.Web.Api.Server.Bases;

namespace Frenchex.Dev.Vos.Web.Api.Server.Controllers.Define.Provisioning.Map;

public class DefineProvisioningMapRequest : IRequest
{
    public Guid RepositoryId { get; set; }
    public DefineProvisioningMapCommandCommandRequest DefineProvisioningMapCommandCommandRequest { get; set; }
}