using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Ssh.Request;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Ssh.Request;

public class SshCommandRequestBuilderFactory : RootCommandRequestBuilderFactory, ISshCommandRequestBuilderFactory
{
    public SshCommandRequestBuilderFactory(IBaseRequestBuilderFactory baseRequestBuilderFactory) : base(
        baseRequestBuilderFactory)
    {
    }

    public ISshCommandRequestBuilder Factory()
    {
        return new SshCommandRequestBuilder(BaseRequestBuilderFactory);
    }
}