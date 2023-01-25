using Microsoft.AspNetCore.Mvc;

namespace Frenchex.Dev.Vos.Web.Api.Server.Controllers.Define.Provisioning.Map;

[ApiController]
public class DefineProvisioningMapController : ControllerBase
{
    [HttpPost("define/provisioning/map")]
    public async Task<IActionResult> MapAsync(
        [FromBody] DefineProvisioningMapRequest request,
        [FromServices] IDefineProvisioningMapAsyncHandler handler,
        CancellationToken cancellationToken = default
    )
    {
        try
        {
            DefineProvisioningMapResponse response = await handler.HandleAsync(request, cancellationToken);
            return new OkObjectResult(response);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }
}