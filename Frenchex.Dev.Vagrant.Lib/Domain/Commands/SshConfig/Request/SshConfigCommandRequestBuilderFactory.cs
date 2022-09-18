using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Root.Base.Request;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.SshConfig.Request;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Root.Request;

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.SshConfig.Request;

public class SshConfigCommandRequestBuilderFactory : RootCommandRequestBuilderFactory,
    ISshConfigCommandRequestBuilderFactory
{
    public SshConfigCommandRequestBuilderFactory(
        IBaseCommandRequestBuilderFactory baseCommandRequestBuilderFactory
    ) : base(baseCommandRequestBuilderFactory)
    {
    }

    public ISshConfigCommandRequestBuilder Factory()
    {
        return new SshConfigCommandRequestBuilder(BaseRequestBuilderFactory);
    }
}