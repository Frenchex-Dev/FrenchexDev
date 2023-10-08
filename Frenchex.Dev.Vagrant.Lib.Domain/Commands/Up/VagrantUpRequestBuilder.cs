#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Up;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Abstractions;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Up;

public class VagrantUpRequestBuilder : AbstractVagrantRequestBuilder, IVagrantUpRequestBuilder
{
    private readonly List<string> _provisionWith = new();
    private          bool         _destroyOnError;
    private          bool         _installProvider;
    private          string       _nameOrId = string.Empty;
    private          bool         _parallel;
    private          string       _provider  = string.Empty;
    private          bool         _provision = true;

    public VagrantUpRequest Build()
    {
        return new VagrantUpRequest(
                                    _nameOrId
                                  , _provision
                                  , _provisionWith.ToArray()
                                  , _destroyOnError
                                  , _parallel
                                  , _provider
                                  , _installProvider
                                  , BaseBuilder.Color
                                  , BaseBuilder.MachineReadable
                                  , BaseBuilder.Version
                                  , BaseBuilder.Debug
                                  , BaseBuilder.Timestamp
                                  , BaseBuilder.DebugTimestamp
                                  , BaseBuilder.NoTty
                                  , BaseBuilder.Help);
    }

    public IVagrantUpRequestBuilder WithNameOrId(
        string nameOrId
    )
    {
        _nameOrId = nameOrId;
        return this;
    }

    public IVagrantUpRequestBuilder WithProvision(
        bool provision
    )
    {
        _provision = provision;
        return this;
    }

    public IVagrantUpRequestBuilder WithProvisionWith(
        string provision
    )
    {
        _provisionWith.Add(provision);
        return this;
    }

    public IVagrantUpRequestBuilder WithDestroyOnError(
        bool destroyOnError
    )
    {
        _destroyOnError = destroyOnError;
        return this;
    }

    public IVagrantUpRequestBuilder WithParallel(
        bool parallel
    )
    {
        _parallel = parallel;
        return this;
    }

    public IVagrantUpRequestBuilder WithProvider(
        string provider
    )
    {
        _provider = provider;
        return this;
    }

    public IVagrantUpRequestBuilder WithInstallProvider(
        bool installProvider
    )
    {
        _installProvider = installProvider;
        return this;
    }
}
