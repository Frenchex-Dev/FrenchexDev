#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using System.CommandLine;

#endregion

namespace Frenchex.Dev.Vos.Cli.Integration.Domain.Options;

public interface IVirtualRamMbOptionBuilder
{
    Option<int> Build();
}

internal class VirtualRamMbOptionBuilder : IVirtualRamMbOptionBuilder
{
    public Option<int> Build()
    {
        return new Option<int>(new[] { "--vram-mb" }, () => 16, "VRAM in MB");
    }
}