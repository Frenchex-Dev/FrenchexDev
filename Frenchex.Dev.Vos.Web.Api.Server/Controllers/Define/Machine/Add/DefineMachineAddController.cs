using Microsoft.AspNetCore.Mvc;

namespace Frenchex.Dev.Vos.Web.Api.Server.Controllers.Define.Machine.Add;

[ApiController]
public class DefineMachineAddController : ControllerBase
{
    [HttpPost("define/machine/add")]
    public async Task<IActionResult> AddAsync(
        [FromBody] DefineMachineAddRequest request,
        [FromServices] IDefineMachineAddRequestAsyncHandler handler,
        CancellationToken cancellationToken = default
    )
    {
        try
        {
            DefineMachineAddResponse response = await handler.HandleAsync(request, cancellationToken);
            return new OkObjectResult(response);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }
}