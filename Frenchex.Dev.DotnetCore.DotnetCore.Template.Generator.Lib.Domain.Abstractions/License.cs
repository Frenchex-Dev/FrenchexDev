namespace Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain.Abstractions;

public class License : ILicense
{
    public required string Content { get; set; }

    public override string ToString() => Content;
}