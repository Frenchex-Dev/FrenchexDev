using System.Collections.Immutable;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Status.Response;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Status.Response;

public class StatusCommandResponseBuilder : IStatusCommandResponseBuilder
{
    private IImmutableDictionary<string, (string, VagrantMachineStatusEnum)>? _statuses;

    public IStatusCommandResponse Build()
    {
        return new StatusCommandResponse(
            _statuses ?? new Dictionary<string, (string, VagrantMachineStatusEnum)>().ToImmutableDictionary()
        );
    }

    public IStatusCommandResponseBuilder WithStatuses(
        IImmutableDictionary<string, (string, VagrantMachineStatusEnum)> statuses
    )
    {
        _statuses = statuses;
        return this;
    }
}