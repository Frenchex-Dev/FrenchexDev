using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.SshConfig.Request;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.SshConfig.Request;

public class SshConfigCommandRequestBuilderFactory : RootCommandRequestBuilderFactory,
    ISshConfigCommandRequestBuilderFactory
{
    public SshConfigCommandRequestBuilderFactory(IBaseRequestBuilderFactory baseRequestBuilderFactory) : base(
        baseRequestBuilderFactory)
    {
    }

    public ISshConfigCommandRequestBuilder Factory()
    {
        return new SshConfigCommandRequestBuilder(BaseRequestBuilderFactory);
    }
}