using Microsoft.AspNetCore.Mvc;

namespace Frenchex.Dev.Vos.Web.Api.Server.Controllers.Init;

[ApiController]
public class InitController : ControllerBase
{
    [HttpPost("init")]
    public async Task<IActionResult> InitAsync(
        [FromBody] InitRequest request,
        [FromServices] IInitRequestAsyncHandler handler,
        CancellationToken cancellationToken = default
    )
    {
        try
        {
            InitResponse response = await handler.HandleAsync(request, cancellationToken);
            return new OkObjectResult(response);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }
}