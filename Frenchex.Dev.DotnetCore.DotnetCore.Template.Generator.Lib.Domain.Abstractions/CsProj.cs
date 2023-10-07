#region Licensing

// Licensing please read LICENSE.md

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain.Abstractions;

public class CsProj : ICsProj
{
    public required string Sdk                       { get; set; }
    public required string TargetFramework           { get; set; }
    public required bool   ImplicitUsings            { get; set; }
    public required bool   Nullable                  { get; set; }
    public required bool   GeneratePackageOnBuild    { get; set; }
    public required bool   IncludeSymbols            { get; set; }
    public required bool   EnforceCodeStyleInBuild   { get; set; }
    public required string PackageLicenseFile        { get; set; }
    public required bool   GenerateDocumentationFile { get; set; }

    public override string ToString()
    {
        return $"<Project Sdk=\"{Sdk}\">\r\n" + "    <ItemGroup>\r\n"
             + "        <None Include=\"README.md\" Pack=\"true\" PackagePath=\"\\\">\r\n"
             + "            <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>\r\n" + "        </None>\r\n"
             + "    </ItemGroup>\r\n"                                                          + "    <PropertyGroup>\r\n"
             + $"        <TargetFramework>{TargetFramework}</TargetFramework>\r\n"
             + $"        <ImplicitUsings>{ImplicitUsings}</ImplicitUsings>\r\n" + $"        <Nullable>{Nullable}</Nullable>\r\n"
             + $"        <GeneratePackageOnBuild>{GeneratePackageOnBuild}</GeneratePackageOnBuild>\r\n"
             + $"        <IncludeSymbols>{IncludeSymbols}</IncludeSymbols>\r\n"
             + $"        <EnforceCodeStyleInBuild>{EnforceCodeStyleInBuild}</EnforceCodeStyleInBuild>\r\n"
             + $"        <PackageLicenseFile>{PackageLicenseFile}</PackageLicenseFile>\r\n"
             + $"        <GenerateDocumentationFile>{GenerateDocumentationFile}</GenerateDocumentationFile>\r\n"
             + "    </PropertyGroup>\r\n" + "</Project>";
    }
}