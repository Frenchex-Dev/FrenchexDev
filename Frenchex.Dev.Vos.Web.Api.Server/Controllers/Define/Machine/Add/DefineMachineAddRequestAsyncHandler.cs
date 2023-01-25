using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Machine.Add.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Machine.Add.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Machine.Add.Response;
using Frenchex.Dev.Vos.Web.Api.Server.Bases;

namespace Frenchex.Dev.Vos.Web.Api.Server.Controllers.Define.Machine.Add;

public class DefineMachineAddRequestAsyncHandler : AbstractAsyncHandler, IDefineMachineAddRequestAsyncHandler
{
    private readonly IDefineMachineAddCommandRequestBuilderFactory _factory;
    private readonly IDefineMachineAddCommand _command;
    private readonly IConfiguration _configuration;

    public DefineMachineAddRequestAsyncHandler(
        IDefineMachineAddCommandRequestBuilderFactory factory,
        IDefineMachineAddCommand command,
        IConfiguration configuration
    )
    {
        _factory = factory;
        _command = command;
        _configuration = configuration;
    }

    public async Task<DefineMachineAddResponse> HandleAsync(DefineMachineAddRequest request, CancellationToken cancellationToken = default)
    {
        string repositoryPath = GetRepositoryPathOrThrowRepositoryNotFound(request.RepositoryId, _configuration);

        IDefineMachineAddCommandRequest libRequest = _factory.Factory()
            .BaseBuilder
            .UsingWorkingDirectory(repositoryPath)
            .Parent<IDefineMachineAddCommandRequestBuilder>()
            .UsingDefinition(request.MachineDefinition)
            .Build();

        IDefineMachineAddCommandResponse libResponse = await _command.ExecuteAsync(libRequest);

        var response = new DefineMachineAddResponse() { IsSuccess = true };

        return response;
    }
}