#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using System.CommandLine;

#endregion

namespace Frenchex.Dev.Vos.Cli.Integration.Domain.Arguments;

public interface IVirtualCpusArgumentBuilder
{
    Argument<int> Build();
}

public class VirtualCpusArgumentBuilder : IVirtualCpusArgumentBuilder
{
    public Argument<int> Build()
    {
        return new Argument<int>("vcpus", "Virtual CPUs");
    }
}