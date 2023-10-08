#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using System.Text.Json.Serialization;

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Abstractions.Solution.Global;

public class Global : IGlobal
{
    [JsonPropertyName("sdk")] public required Sdk Sdk { get; set; }
}
