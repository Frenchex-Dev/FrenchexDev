using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Base;

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Abstractions;

public class AbstractVagrantRequestBuilder
{
    protected readonly BaseVagrantCommandRequestBuilder BaseBuilder;

    public AbstractVagrantRequestBuilder()
    {
        BaseBuilder = new BaseVagrantCommandRequestBuilder(this);
    }

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public IBaseVagrantCommandRequestBuilder Base()
    {
        return BaseBuilder;
    }
}
