﻿#region Licensing

// Licensing please read LICENSE.md

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Project.AddPackage.Lib.Domain.Abstractions;

public class CsProj : ICsProj
{
    public required string Path { get; set; }
}