#region Licensing

// Licensing please read LICENSE.md

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain.Abstractions;

public class TemplateInstallationErrorResult : ITemplateInstallationResult
{
    public required string     Error     { get; set; }
    public          Exception? Exception { get; set; }
}
