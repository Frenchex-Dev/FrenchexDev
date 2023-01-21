#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using System.CommandLine;

#endregion

namespace Frenchex.Dev.Vos.Cli.Integration.Domain.Arguments;

public interface IInstancesArgumentBuilder
{
    Argument<int> Build();
}

public class InstancesArgumentBuilder : IInstancesArgumentBuilder
{
    public Argument<int> Build()
    {
        return new Argument<int>("instances", "# of instances");
    }
}