using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Provision.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Provision.Request;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Provision.Request;
using Frenchex.Dev.Vos.Web.Api.Server.Bases;
using Microsoft.AspNetCore.Mvc;

namespace Frenchex.Dev.Vos.Web.Api.Server.Controllers.Provision;

[ApiController]
public class ProvisionController : ControllerBase
{
    [HttpPost("provision")]
    public async Task<IActionResult> ProvisionAsync(
        [FromBody] ProvisionRequest request,
        [FromServices] IProvisionAsyncHandler handler,
        CancellationToken cancellationToken = default
    )
    {
        try
        {
            var response = await handler.HandleAsync(request, cancellationToken);
            return new OkObjectResult(response);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }
}

public class ProvisionRequest : IRequest
{
    public Guid RepositoryId { get; set; }
    public ProvisionCommandRequest ProvisionCommandRequest { get; set; }
}

public class ProvisionError : IError
{

}

public class ProvisionResponse : IResponse<ProvisionError>
{
    public bool IsSuccess { get; set; }
    public List<ProvisionError> Errors { get; set; }
}

public interface IProvisionAsyncHandler : IAsyncHandler<ProvisionRequest, ProvisionResponse, ProvisionError>
{

}

public class ProvisionAsyncHandler : AbstractAsyncHandler, IProvisionAsyncHandler
{
    private readonly IProvisionCommandRequestBuilderFactory _factory;
    private readonly IProvisionCommand _command;
    private readonly IConfiguration _configuration;

    public ProvisionAsyncHandler(
        IProvisionCommandRequestBuilderFactory factory,
        IProvisionCommand command,
        IConfiguration configuration
    )
    {
        _factory = factory;
        _command = command;
        _configuration = configuration;
    }

    public async Task<ProvisionResponse> HandleAsync(ProvisionRequest request, CancellationToken cancellationToken = default)
    {
        string repositoryPath = GetRepositoryPathOrThrowRepositoryNotFound(request.RepositoryId, _configuration);

        var libRequest = _factory.Factory()
            .BaseBuilder
            .UsingWorkingDirectory(repositoryPath)
            .Parent<IProvisionCommandRequestBuilder>()
            .UsingNames(request.ProvisionCommandRequest.Names)
            .UsingProvisionWith(request.ProvisionCommandRequest.ProvisionWith)
            .Enable()
            .Build();

        var libResponse = await _command.ExecuteAsync(libRequest);

        return new ProvisionResponse() { IsSuccess = true };
    }
}