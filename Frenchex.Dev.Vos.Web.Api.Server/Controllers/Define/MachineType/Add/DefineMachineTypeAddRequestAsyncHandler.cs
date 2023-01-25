using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.MachineType.Add.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.MachineType.Add.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.MachineType.Add.Response;
using Frenchex.Dev.Vos.Web.Api.Server.Bases;

namespace Frenchex.Dev.Vos.Web.Api.Server.Controllers.Define.MachineType.Add;

public class DefineMachineTypeAddRequestAsyncHandler : AbstractAsyncHandler, IDefineMachineTypeAddRequestAsyncHandler
{
    private readonly IDefineMachineTypeAddCommandRequestBuilderFactory _factory;
    private readonly IDefineMachineTypeAddCommand _command;
    private readonly IConfiguration _configuration;

    public DefineMachineTypeAddRequestAsyncHandler(
        IDefineMachineTypeAddCommandRequestBuilderFactory factory,
        IDefineMachineTypeAddCommand command,
        IConfiguration configuration
    )
    {
        _factory = factory;
        _command = command;
        _configuration = configuration;
    }

    public async Task<DefineMachineTypeAddResponse> HandleAsync(DefineMachineTypeAddRequest request, CancellationToken cancellationToken = default)
    {
        string repositoryPath = GetRepositoryPathOrThrowRepositoryNotFound(request.RepositoryId, _configuration);

        IDefineMachineTypeAddCommandRequest libRequest = _factory.Factory()
            .BaseBuilder
            .UsingWorkingDirectory(repositoryPath)
            .Parent<IDefineMachineTypeAddCommandRequestBuilder>()
            .UsingDefinition(request.MachineTypeDefinitionDeclaration)
            .Build();

        IDefineMachineTypeAddCommandResponse responseLib = await _command.ExecuteAsync(libRequest);

        var response = new DefineMachineTypeAddResponse() { IsSuccess = true };

        return response;
    }
}