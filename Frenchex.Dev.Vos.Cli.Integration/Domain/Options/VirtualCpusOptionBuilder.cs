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

public interface IVirtualCpusOptionBuilder
{
    Option<int> Build();
}

public class VirtualCpusOptionBuilder : IVirtualCpusOptionBuilder
{
    public Option<int> Build()
    {
        return new Option<int>(new[] { "--vcpus", "-c" }, () => 2, "Virtual CPUs");
    }
}