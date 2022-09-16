using System.CommandLine;

namespace Frenchex.Dev.Vos.Cli.Integration.Domain.Options;

public interface IColorOptionBuilder
{
    Option<bool> Build();
}

public class ColorOptionBuilder : IColorOptionBuilder
{
    public Option<bool> Build()
    {
        return new Option<bool>(new[] {"--color"}, "Coor");
    }
}