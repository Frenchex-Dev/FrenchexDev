using Frenchex.Dev.Dotnet.Core.Filesystem.Lib.Domain;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Actions.Configuration.Load;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Actions.Configuration.Save;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Actions.Naming;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Init.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Init.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Init.Response;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Configuration;
using Frenchex.Dev.Vos.Lib.Domain.Resources;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Init.Command;

public class InitCommand : RootCommand, IInitCommand
{
    private readonly IConfigurationSaveAction _configurationActionSave;
    private readonly IFilesystem _filesystem;
    private readonly IInitCommandCommandResponseBuilderFactory _commandResponseBuilderFactory;
    private readonly IVagrantfileResource _vagrantfileResource;

    public InitCommand(
        IFilesystem fileSystemOperator,
        IVagrantfileResource vagrantfileResource,
        IInitCommandCommandResponseBuilderFactory commandResponseBuilderFactory,
        IConfigurationSaveAction configurationActionSave,
        IConfigurationLoadAction configurationLoadAction,
        IVexNameToVagrantNameConverter nameConverter
    ) : base(configurationLoadAction, nameConverter)
    {
        _filesystem = fileSystemOperator;
        _vagrantfileResource = vagrantfileResource;
        _commandResponseBuilderFactory = commandResponseBuilderFactory;
        _configurationActionSave = configurationActionSave;
    }

    public async Task<IInitCommandResponse> ExecuteAsync(IInitCommandRequest request)
    {
        if (request.Base.WorkingDirectory == null)
            throw new ArgumentNullException(nameof(request.Base.WorkingDirectory));

        if (!_filesystem.DirectoryExists(request.Base.WorkingDirectory))
            _filesystem.DirectoryCreate(request.Base.WorkingDirectory);

        _vagrantfileResource.Copy(request.Base.WorkingDirectory);

        await _configurationActionSave.Save(
            new Configuration(), // @todo make it buildable via opts
            Path.Join(request.Base.WorkingDirectory, "config.json")
        );

        var provisioningPath = Path.GetFullPath("provisioning", request.Base.WorkingDirectory);
        var provisioningPathLink =
            Path.GetFullPath(Path.Join("Resources", "Provisioning"), AppDomain.CurrentDomain.BaseDirectory);

        _filesystem.DirectoryCopy(provisioningPathLink, provisioningPath);

        return _commandResponseBuilderFactory
            .Factory()
            .Build();
    }
}