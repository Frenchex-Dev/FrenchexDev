namespace Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain.Abstractions;

public interface ICsProj
{
    string ToString();

    string Sdk                       { get;  }
    string TargetFramework           { get; }
    bool   ImplicitUsings            { get; }
    bool   Nullable                  { get; }
    bool   GeneratePackageOnBuild    { get; }
    bool   IncludeSymbols            { get; }
    bool   EnforceCodeStyleInBuild   { get; }
    string PackageLicenseFile        { get; }
    bool   GenerateDocumentationFile { get; }
}