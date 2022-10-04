using System.Collections.Immutable;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Response;

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Status.Response;

public interface IStatusCommandCommandResponseBuilder : IRootCommandResponseBuilder
{
    IStatusCommandResponse Build();

    IStatusCommandCommandResponseBuilder WithStatuses(
        IImmutableDictionary<string, (string, VagrantMachineStatusEnum)> statuses
    );
}