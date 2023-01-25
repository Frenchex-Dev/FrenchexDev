using Microsoft.AspNetCore.Mvc;

namespace Frenchex.Dev.Vos.Web.Api.Server.Controllers.Define.MachineType.Add;

[ApiController]
public class DefineMachineTypeController : ControllerBase
{
    [HttpPost("define/machine-type/add")]
    public async Task<IActionResult> AddAsync(
        [FromBody] DefineMachineTypeAddRequest request,
        [FromServices] IDefineMachineTypeAddRequestAsyncHandler handler,
        CancellationToken cancellationToken = default
    )
    {
        try
        {
            DefineMachineTypeAddResponse response = await handler.HandleAsync(request, cancellationToken);
            return new OkObjectResult(response);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }
}