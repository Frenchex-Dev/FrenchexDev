using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Up.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Up.Request;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Up.Request;
using Frenchex.Dev.Vos.Web.Api.Server.Bases;
using Microsoft.AspNetCore.Mvc;

namespace Frenchex.Dev.Vos.Web.Api.Server.Controllers.Up;

[ApiController]
public class UpController : ControllerBase
{
    [HttpPost("Up")]
    public async Task<IActionResult> UpAsync(
        [FromBody] UpRequest request,
        [FromServices] IUpAsyncHandler handler,
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

public class UpRequest : IRequest
{
    public Guid RepositoryId { get; set; }
    public UpCommandRequest UpCommandRequest { get; set; }
}

public class UpError : IError
{

}

public class UpResponse : IResponse<UpError>
{
    public bool IsSuccess { get; set; }
    public List<UpError> Errors { get; set; }
}

public interface IUpAsyncHandler : IAsyncHandler<UpRequest, UpResponse, UpError>
{

}

public class UpAsyncHandler : AbstractAsyncHandler, IUpAsyncHandler
{
    private readonly IUpCommandRequestBuilderFactory _factory;
    private readonly IUpCommand _command;
    private readonly IConfiguration _configuration;

    public UpAsyncHandler(
        IUpCommandRequestBuilderFactory factory,
        IUpCommand command,
        IConfiguration configuration
    )
    {
        _factory = factory;
        _command = command;
        _configuration = configuration;
    }

    public async Task<UpResponse> HandleAsync(UpRequest request, CancellationToken cancellationToken = default)
    {
        string repositoryPath = GetRepositoryPathOrThrowRepositoryNotFound(request.RepositoryId, _configuration);

        var libRequest = _factory.Factory()
            .BaseBuilder
            .UsingWorkingDirectory(repositoryPath)
            .Parent<IUpCommandRequestBuilder>()
            .UsingNames(request.UpCommandRequest.Names)
            .UsingProvisionWith(request.UpCommandRequest.ProvisionWith)
            .Build();

        var libResponse = await _command.ExecuteAsync(libRequest);

        return new UpResponse() { IsSuccess = true };
    }
}