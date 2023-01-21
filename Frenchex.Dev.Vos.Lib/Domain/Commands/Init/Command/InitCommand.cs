#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

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

#endregion

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Init.Command;

public class InitCommand : RootCommand, IInitCommand
{
    private readonly IConfigurationSaveAction _configurationActionSave;
    private readonly IFilesystem _filesystem;
    private readonly IInitCommandResponseBuilderFactory _responseBuilderFactory;
    private readonly IScriptsResource _scriptsResource;
    private readonly IVagrantfileResource _vagrantfileResource;

    public InitCommand(
        IFilesystem fileSystemOperator,
        IVagrantfileResource vagrantfileResource,
        IScriptsResource scriptsResource,
        IInitCommandResponseBuilderFactory responseBuilderFactory,
        IConfigurationSaveAction configurationActionSave,
        IConfigurationLoadAction configurationLoadAction,
        IVosNameToVagrantNameConverter nameConverter
    ) : base(configurationLoadAction, nameConverter)
    {
        _filesystem = fileSystemOperator;
        _vagrantfileResource = vagrantfileResource;
        _scriptsResource = scriptsResource;
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

        _scriptsResource.Copy(request.BaseCommand.WorkingDirectory);

        await _configurationActionSave.Save(
            new Configuration(), // @todo make it buildable via opts
            request.BaseCommand.WorkingDirectory
        );

        string? provisioningPath =
            Path.GetFullPath(IVagrantfileResource.Provisioning, request.BaseCommand.WorkingDirectory);
        string? provisioningPathLink =
            Path.GetFullPath(Path.Join("Resources", IVagrantfileResource.Provisioning),
                AppDomain.CurrentDomain.BaseDirectory);

        _filesystem.DirectoryCopy(provisioningPathLink, provisioningPath);

        return _responseBuilderFactory
            .Factory()
            .Build();
    }
}