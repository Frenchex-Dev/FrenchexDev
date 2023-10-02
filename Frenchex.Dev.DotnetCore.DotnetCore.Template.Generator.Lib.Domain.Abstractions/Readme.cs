namespace Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain.Abstractions;

public class Readme : IReadme
{
    public required string Content { get; set; }

    public override string ToString()
    {
        return Content;
    }
}
