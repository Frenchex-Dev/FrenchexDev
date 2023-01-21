#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using System.Collections.Immutable;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Status.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Actions.Configuration.Load;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Actions.Naming;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Status.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Status.Response;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Root.Command;
using IStatusCommandRequest = Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Status.Request.IStatusCommandRequest;

#endregion

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Status.Command;

public class StatusCommand : RootCommand, IStatusCommand
{
    private readonly IStatusCommandResponseBuilderFactory _statusCommandResponseBuilderFactory;
    private readonly Vagrant.Lib.Abstractions.Domain.Commands.Status.Command.IStatusCommand _vagrantStatusCommand;

    private readonly IStatusCommandRequestBuilderFactory
        _vagrantStatusCommandRequestBuilderFactory;

    public StatusCommand(
        IConfigurationLoadAction configurationLoadAction,
        IStatusCommandResponseBuilderFactory statusCommandResponseBuilderFactory,
        IVosNameToVagrantNameConverter nameConverter,
        Vagrant.Lib.Abstractions.Domain.Commands.Status.Command.IStatusCommand statusCommand,
        IStatusCommandRequestBuilderFactory
            statusCommandRequestBuilderFactory
    ) : base(configurationLoadAction, nameConverter)
    {
        _statusCommandResponseBuilderFactory = statusCommandResponseBuilderFactory;
        _vagrantStatusCommand = statusCommand;
        _vagrantStatusCommandRequestBuilderFactory = statusCommandRequestBuilderFactory;
    }

    public async Task<IStatusCommandResponse> ExecuteAsync(IStatusCommandRequest request)
    {
        var process = _vagrantStatusCommand.StartProcess(
            _vagrantStatusCommandRequestBuilderFactory.Factory()
                .BaseBuilder
                .UsingWorkingDirectory(request.BaseCommand.WorkingDirectory)
                .Parent<IStatusCommandRequestBuilder>()
                .WithNamesOrIds(MapNamesToVagrantNames(
                        request.Names,
                        request.BaseCommand.WorkingDirectory,
                        await ConfigurationLoad(request.BaseCommand.WorkingDirectory)
                    )
                )
                .Build()
        );


        if (null == process.ProcessExecutionResult.WaitForCompleteExit
            || null == process.ProcessExecutionResult.OutputStream
           )
            throw new InvalidOperationException("wait for complete exit is null");

        await process.ProcessExecutionResult.WaitForCompleteExit;

        process.ProcessExecutionResult.OutputStream.Position = 0;
        var reader = new StreamReader(process.ProcessExecutionResult.OutputStream);

        List<string>? statusesOutput = (await reader.ReadToEndAsync())
            .Split("\r\n")
            .Skip(2) // vagrant header
            .Reverse()
            .Skip(5) // vagrant footer
            .Reverse()
            .Where(x => !string.IsNullOrEmpty(x)) // only not empty lines
            .ToList();

        Dictionary<string, (string, VagrantMachineStatusEnum)> statuses = new();

        foreach (var item in statusesOutput)
        {
            List<string>? statusLineSplit = item
                .Split(" ")
                .ToList();

            var machine = statusLineSplit
                .First()
                .Trim();

            var statusString = (statusLineSplit[^3] + " " + statusLineSplit[^2].Trim())
                .Trim();

            var providerString = statusLineSplit[^1]
                .Replace("(", "")
                .Replace(")", "")
                .Trim();

            var status = VagrantMachineStatusEnum.NotCreated;

            switch (statusString)
            {
                case "not created":
                    status = VagrantMachineStatusEnum.NotCreated;
                    break;
                case "running":
                    status = VagrantMachineStatusEnum.Running;
                    break;
                case "aborted":
                    status = VagrantMachineStatusEnum.Aborted;
                    break;
                case "suspended":
                    status = VagrantMachineStatusEnum.Suspended;
                    break;
                case "stopped":
                    status = VagrantMachineStatusEnum.Stopped;
                    break;
            }

            statuses.Add(machine, (providerString, status));
        }

        return _statusCommandResponseBuilderFactory.Factory()
            .WithStatuses(statuses.ToImmutableDictionary())
            .Build();
    }
}