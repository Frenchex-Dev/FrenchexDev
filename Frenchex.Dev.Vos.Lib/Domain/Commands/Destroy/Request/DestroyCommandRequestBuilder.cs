using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Destroy.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Destroy.Request;

public class DestroyCommandRequestBuilder : RootCommandRequestBuilder, IDestroyCommandRequestBuilder
{
    private string? _withDestroyTimeoutTs;
    private bool? _withForce;
    private bool? _withGraceful;
    private string? _withName;
    private bool? _withParallel;

    public DestroyCommandRequestBuilder(IBaseRequestBuilderFactory baseRequestBuilderFactory) : base(
        baseRequestBuilderFactory)
    {
    }

    public IDestroyCommandRequest Build()
    {
        return new DestroyCommandRequest(
            _withName ?? "",
            _withForce ?? false,
            _withParallel ?? false,
            _withGraceful ?? false,
            BaseBuilder.Build(),
            _withDestroyTimeoutTs
        );
    }

    public IDestroyCommandRequestBuilder UsingName(string? nameOrId)
    {
        _withName = nameOrId;
        return this;
    }

    public IDestroyCommandRequestBuilder UsingDestroyTimeout(string timeout)
    {
        _withDestroyTimeoutTs = timeout;
        return this;
    }

    public IDestroyCommandRequestBuilder WithForce(bool force)
    {
        _withForce = force;
        return this;
    }

    public IDestroyCommandRequestBuilder WithGraceful(bool graceful)
    {
        _withGraceful = graceful;
        return this;
    }

    public IDestroyCommandRequestBuilder WithParallel(bool parallel)
    {
        _withParallel = parallel;
        return this;
    }
}