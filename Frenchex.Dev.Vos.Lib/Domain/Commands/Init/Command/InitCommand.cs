using Frenchex.Dev.Dotnet.Core.Filesystem.Lib.Domain;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Actions.Configuration.Load;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Actions.Configuration.Save;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Actions.Naming;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Init.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Init.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Init.Response;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Configuration;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Root.Command;
using Frenchex.Dev.Vos.Lib.Domain.Resources;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Init.Command;

public class InitCommand : RootCommand, IInitCommand
{
    private readonly IConfigurationSaveAction _configurationActionSave;
    private readonly IFilesystem _filesystem;
    private readonly IInitCommandResponseBuilderFactory _responseBuilderFactory;
    private readonly IVagrantfileResource _vagrantfileResource;

    public InitCommand(
        IFilesystem fileSystemOperator,
        IVagrantfileResource vagrantfileResource,
        IInitCommandResponseBuilderFactory responseBuilderFactory,
        IConfigurationSaveAction configurationActionSave,
        IConfigurationLoadAction configurationLoadAction,
        IVexNameToVagrantNameConverter nameConverter
    ) : base(configurationLoadAction, nameConverter)
    {
        _filesystem = fileSystemOperator;
        _vagrantfileResource = vagrantfileResource;
        _responseBuilderFactory = responseBuilderFactory;
        _configurationActionSave = configurationActionSave;
    }

    public async Task<IInitCommandResponse> ExecuteAsync(IInitCommandRequest request)
    {
        if (request.BaseCommand.WorkingDirectory == null)
            throw new ArgumentNullException(nameof(request.BaseCommand.WorkingDirectory));

        if (!_filesystem.DirectoryExists(request.BaseCommand.WorkingDirectory))
            _filesystem.DirectoryCreate(request.BaseCommand.WorkingDirectory);

        _vagrantfileResource.Copy(request.BaseCommand.WorkingDirectory);

        await _configurationActionSave.Save(
            new Configuration(), // @todo make it buildable via opts
            Path.Join(request.BaseCommand.WorkingDirectory, "config.json")
        );

        var provisioningPath = Path.GetFullPath("provisioning", request.BaseCommand.WorkingDirectory);
        var provisioningPathLink =
            Path.GetFullPath(Path.Join("Resources", "Provisioning"), AppDomain.CurrentDomain.BaseDirectory);

        _filesystem.DirectoryCopy(provisioningPathLink, provisioningPath);

        return _responseBuilderFactory
            .Factory()
            .Build();
    }
}