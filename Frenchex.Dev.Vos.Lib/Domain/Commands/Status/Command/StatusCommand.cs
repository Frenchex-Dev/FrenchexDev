﻿using System.Collections.Immutable;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Actions.Configuration.Load;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Actions.Naming;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Status.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Status.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Status.Response;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Status.Command;

public class StatusCommand : RootCommand, IStatusCommand
{
    private readonly IStatusCommandCommandResponseBuilderFactory _statusCommandCommandResponseBuilderFactory;
    private readonly Vagrant.Lib.Abstractions.Domain.Commands.Status.Command.IStatusCommand _vagrantStatusCommand;

    private readonly Vagrant.Lib.Abstractions.Domain.Commands.Status.Request.IStatusCommandRequestBuilderFactory
        _vagrantStatusCommandRequestBuilderFactory;

    public StatusCommand(
        IConfigurationLoadAction configurationLoadAction,
        IStatusCommandCommandResponseBuilderFactory statusCommandCommandResponseBuilderFactory,
        IVexNameToVagrantNameConverter nameConverter,
        Vagrant.Lib.Abstractions.Domain.Commands.Status.Command.IStatusCommand statusCommand,
        Vagrant.Lib.Abstractions.Domain.Commands.Status.Request.IStatusCommandRequestBuilderFactory
            statusCommandRequestBuilderFactory
    ) : base(configurationLoadAction, nameConverter)
    {
        _statusCommandCommandResponseBuilderFactory = statusCommandCommandResponseBuilderFactory;
        _vagrantStatusCommand = statusCommand;
        _vagrantStatusCommandRequestBuilderFactory = statusCommandRequestBuilderFactory;
    }

    public async Task<IStatusCommandResponse> ExecuteAsync(IStatusCommandRequest request)
    {
        var process = _vagrantStatusCommand.StartProcess(
            _vagrantStatusCommandRequestBuilderFactory.Factory()
                .BaseBuilder
                .UsingWorkingDirectory(request.Base.WorkingDirectory)
                .Parent<Vagrant.Lib.Abstractions.Domain.Commands.Status.Request.IStatusCommandRequestBuilder>()
                .WithNamesOrIds(MapNamesToVagrantNames(
                        request.Names,
                        request.Base.WorkingDirectory,
                        await ConfigurationLoad(request.Base.WorkingDirectory)
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

        List<string> statusesOutput = (await reader.ReadToEndAsync())
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
            List<string> statusLineSplit = item
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

        return _statusCommandCommandResponseBuilderFactory.Factory()
            .WithStatuses(statuses.ToImmutableDictionary())
            .Build();
    }
}