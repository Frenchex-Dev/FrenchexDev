using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Provisioning.Map.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Provisioning.Map.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Provisioning.Map.Response;
using Frenchex.Dev.Vos.Web.Api.Server.Bases;

namespace Frenchex.Dev.Vos.Web.Api.Server.Controllers.Define.Provisioning.Map;

public class DefineProvisioningMapAsyncHandler : AbstractAsyncHandler, IDefineProvisioningMapAsyncHandler
{
    private readonly IDefineProvisioningMapCommandRequestBuilderFactory _factory;
    private readonly IDefineProvisioningMapCommand _command;
    private readonly IConfiguration _configuration;

    public DefineProvisioningMapAsyncHandler(
        IDefineProvisioningMapCommandRequestBuilderFactory factory,
        IDefineProvisioningMapCommand command,
        IConfiguration configuration
    )
    {
        _factory = factory;
        _command = command;
        _configuration = configuration;
    }

    public async Task<DefineProvisioningMapResponse> HandleAsync(DefineProvisioningMapRequest request, CancellationToken cancellationToken = default)
    {
        string repositoryPath = GetRepositoryPathOrThrowRepositoryNotFound(request.RepositoryId, _configuration);

        IDefineProvisioningMapCommandRequest libRequest = _factory.Factory()
            .BaseBuilder
            .UsingWorkingDirectory(repositoryPath)
            .Parent<IDefineProvisioningMapCommandRequestBuilder>()
            .Enabled(request.DefineProvisioningMapCommandCommandRequest.Enable)
            .Privileged(request.DefineProvisioningMapCommandCommandRequest.Privileged)
            .Build();

        IDefineProvisioningMapCommandResponse responseLib = await _command.ExecuteAsync(libRequest);

        DefineProvisioningMapResponse response = new DefineProvisioningMapResponse() { IsSuccess = true };

        return response;
    }
}