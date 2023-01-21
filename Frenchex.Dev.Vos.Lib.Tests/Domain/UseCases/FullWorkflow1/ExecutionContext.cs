#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Dotnet.Core.UnitTesting.Lib.Domain;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Machine.Add.Response;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.MachineType.Add.Response;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Destroy.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Destroy.Response;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Halt.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Halt.Response;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Init.Response;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Name.Response;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Ssh.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Ssh.Response;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.SshConfig.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.SshConfig.Response;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Status.Response;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Up.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Up.Response;

#endregion

namespace Frenchex.Dev.Vos.Lib.Tests.Domain.UseCases.FullWorkflow1;

public class ExecutionContext : WithWorkingDirectoryExecutionContext
{
    public IInitCommandResponse? InitCommandResponse { get; set; }
    public List<IDefineMachineTypeAddCommandResponse>? DefineMachineTypeAddCommandsResponses { get; set; }
    public List<IDefineMachineAddCommandResponse>? DefineMachineAddCommandsResponses { get; set; }
    public List<(NameCommandRequestPayload, INameCommandResponse)>? NameCommandsResponses { get; set; }
    public List<IStatusCommandResponse>? StatusCommandsResponseBeforeUp { get; set; }
    public List<string>? WillBeUp { get; set; }
    public List<(IUpCommandRequest, IUpCommandResponse)>? UpCommandsResponses { get; set; }
    public List<(ISshConfigCommandRequest, ISshConfigCommandResponse)>? SshConfigCommandsResponses { get; set; }
    public List<(ISshCommandRequest, ISshCommandResponse)>? SshCommandsResponses { get; set; }
    public List<(IHaltCommandRequest, IHaltCommandResponse)>? HaltCommandsResponses { get; set; }
    public List<(IDestroyCommandRequest, IDestroyCommandResponse)>? DestroyCommandsResponses { get; set; }
}