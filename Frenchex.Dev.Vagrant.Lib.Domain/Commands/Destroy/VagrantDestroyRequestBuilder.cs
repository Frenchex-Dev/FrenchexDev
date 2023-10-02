#region Usings

using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Destroy;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Abstractions;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Destroy;

public class VagrantDestroyRequestBuilder : AbstractVagrantRequestBuilder, IVagrantDestroyRequestBuilder
{
    private bool   _force;
    private bool   _graceful;
    private string _nameOrId = string.Empty;
    private bool   _parallel;

    public VagrantDestroyRequest Build()
    {
        return new VagrantDestroyRequest(_nameOrId, _force, _parallel, _graceful, BaseBuilder.Color
                                       , BaseBuilder.MachineReadable, BaseBuilder.Version, BaseBuilder.Debug
                                       , BaseBuilder.Timestamp, BaseBuilder.DebugTimestamp, BaseBuilder.NoTty
                                       , BaseBuilder.Help);
    }

    public IVagrantDestroyRequestBuilder WithNameOrId(
        string nameOrId
    )
    {
        _nameOrId = nameOrId;
        return this;
    }

    public IVagrantDestroyRequestBuilder WithGraceful(
        bool graceful
    )
    {
        _graceful = graceful;
        return this;
    }

    public IVagrantDestroyRequestBuilder WithForce(
        bool force
    )
    {
        _force = force;
        return this;
    }

    public IVagrantDestroyRequestBuilder WithParallel(
        bool parallel
    )
    {
        _parallel = parallel;
        return this;
    }
}
