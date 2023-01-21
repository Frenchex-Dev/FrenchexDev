using System.CommandLine;

namespace Frenchex.Dev.Vos.Cli.Integration.Domain.Arguments
{
    public interface IVersionArgumentBuilder
    {
        Argument<string> Build();
    }
    public class VersionArgumentBuilder : IVersionArgumentBuilder
    {
        public Argument<string> Build()
        {
            return new Argument<string>("version", "Provision version");
        }
    }
}
