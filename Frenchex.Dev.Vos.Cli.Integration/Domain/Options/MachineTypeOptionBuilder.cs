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

public interface IMachineTypeOptionBuilder
{
    Option<bool> Build();
}

public class MachineTypeOptionBuilder : IMachineTypeOptionBuilder
{
    public Option<bool> Build()
    {
        return new Option<bool>(new[] { "--machine-type" }, "Machine type");
    }
}