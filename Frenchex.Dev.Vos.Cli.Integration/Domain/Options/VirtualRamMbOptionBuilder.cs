using System.CommandLine;

namespace Frenchex.Dev.Vos.Cli.Integration.Domain.Options;

public interface IVirtualRamMbOptionBuilder
{
    Option<int> Build();
}

internal class VirtualRamMbOptionBuilder : IVirtualRamMbOptionBuilder
{
    public Option<int> Build()
    {
        return new Option<int>(new[] {"--vram-mb"}, () => 16, "VRAM in MB");
    }
}