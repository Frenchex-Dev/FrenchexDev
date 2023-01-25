using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Init.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Init.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Init.Response;
using Frenchex.Dev.Vos.Web.Api.Server.Bases;

namespace Frenchex.Dev.Vos.Web.Api.Server.Controllers.Init;

public class InitRequestAsyncHandler : AbstractAsyncHandler, IInitRequestAsyncHandler
{
    private readonly IInitCommandRequestBuilderFactory _factory;
    private readonly IInitCommand _command;
    private readonly IConfiguration _configuration;

    public InitRequestAsyncHandler(
        IInitCommandRequestBuilderFactory factory,
        IInitCommand command,
        IConfiguration configuration
    )
    {
        _factory = factory;
        _command = command;
        _configuration = configuration;
    }

    public async Task<InitResponse> HandleAsync(InitRequest request, CancellationToken cancellationToken = default)
    {
        string? rootPath = GetVosRootPathFromConfiguration(_configuration);

        if (rootPath == null)
        {
            throw new ArgumentNullException(nameof(rootPath));
        }

        if (!Directory.Exists(rootPath))
        {
            Directory.CreateDirectory(rootPath);
        }

        IInitCommandRequest? libRequest = _factory.Factory()
            .BaseBuilder
            .UsingWorkingDirectory(Path.Join(rootPath, request.Id.ToString()))
            .Parent<IInitCommandRequestBuilder>()
            .Build();

        IInitCommandResponse? libResponse = await _command.ExecuteAsync(libRequest);

        var response = new InitResponse() { IsSuccess = true };

        return response;
    }


}