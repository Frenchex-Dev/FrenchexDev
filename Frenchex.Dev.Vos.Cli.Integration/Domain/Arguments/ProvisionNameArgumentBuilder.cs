using System.CommandLine;

namespace Frenchex.Dev.Vos.Cli.Integration.Domain.Arguments
{
    public interface IProvisionNameArgumentBuilder
    {
        Argument<string> Build();
    }
    public class ProvisionNameArgumentBuilder : IProvisionNameArgumentBuilder
    {
        public Argument<string> Build()
        {
            return new Argument<string>("provision", "Provisioning name");
        }
    }
}
