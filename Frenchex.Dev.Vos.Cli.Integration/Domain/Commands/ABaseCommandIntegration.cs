﻿#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Vos.Cli.Integration.Domain.Options;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Request;

#endregion

namespace Frenchex.Dev.Vos.Cli.Integration.Domain.Commands;

public class ABaseCommandIntegration
{
    protected readonly ITimeoutMsOptionBuilder TimeoutStrOptionBuilder;
    protected readonly IVagrantBinPathOptionBuilder VagrantBinPathOptionBuilder;
    protected readonly IWorkingDirectoryOptionBuilder WorkingDirectoryOptionBuilder;

    public ABaseCommandIntegration(
        IWorkingDirectoryOptionBuilder workingDirectoryOptionBuilder,
        ITimeoutMsOptionBuilder timeoutStrOptionBuilder,
        IVagrantBinPathOptionBuilder vagrantBinPathOptionBuilder
    )
    {
        WorkingDirectoryOptionBuilder = workingDirectoryOptionBuilder;
        TimeoutStrOptionBuilder = timeoutStrOptionBuilder;
        VagrantBinPathOptionBuilder = vagrantBinPathOptionBuilder;
    }

    protected static void BuildBase(IRootCommandRequestBuilder requestBuilder, CommandIntegrationPayload payload)
    {
        requestBuilder
            .BaseBuilder
            .WithDebug(true)
            .UsingWorkingDirectory(payload.WorkingDirectory)
            .UsingTimeout(payload.TimeoutString)
            .UsingVagrantBinPath(payload.VagrantBinPath)
            ;
    }
}