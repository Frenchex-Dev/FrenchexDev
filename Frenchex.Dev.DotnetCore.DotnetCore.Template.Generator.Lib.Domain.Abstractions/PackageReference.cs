namespace Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain.Abstractions;

public class PackageReference : IPackageReference
{
    public required string Name    { get; set; }
    public required string Version { get; set; }
}
