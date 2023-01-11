#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Dotnet.Wrapping.Lib.Domain.Commands.Root;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Build.Request;

#endregion

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Build.Request;

public class BuildCommandRequest : IBuildCommandRequest
{
    public BuildCommandRequest(IBaseCommandRequest @base, string template)
    {
        Base = @base ?? throw new ArgumentNullException(nameof(@base));
        Template = template ?? throw new ArgumentNullException(nameof(template));
    }

    public IBaseCommandRequest Base { get; }
    public string Template { get; }
    public bool? Color { get; }
    public bool? Debug { get; }
    public string[]? Except { get; }
    public string[]? Only { get; }
    public bool? Force { get; }
    public bool? MachineReadable { get; }
    public OnErrorEnum? OnError { get; }
    public int? ParallelBuilds { get; }
    public bool? TimestampUi { get; }
    public string[]? Vars { get; }
    public string? VarFilePath { get; }
}