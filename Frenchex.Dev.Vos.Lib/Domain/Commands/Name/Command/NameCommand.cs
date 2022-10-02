using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Actions.Configuration.Load;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Actions.Naming;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Name.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Name.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Name.Response;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Name.Command;

public class NameCommand : RootCommand, INameCommand
{
    private readonly INameCommandResponseBuilderFactory _responseBuilderFactory;

    public NameCommand(
        INameCommandResponseBuilderFactory responseBuilderFactory,
        IConfigurationLoadAction configurationLoadAction,
        IVexNameToVagrantNameConverter vexNameToVagrantNameConverter
    ) : base(configurationLoadAction, vexNameToVagrantNameConverter)
    {
        _responseBuilderFactory = responseBuilderFactory;
    }

    public async Task<INameCommandResponse> ExecuteAsync(INameCommandRequest request)
    {
        var config = await ConfigurationLoad(request.Base.WorkingDirectory);

        return _responseBuilderFactory
            .Factory()
            .SetNames(NameToVagrantNameConverter.ConvertAll(request.Names, request.Base.WorkingDirectory, config))
            .Build();
    }
}