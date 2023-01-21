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

public interface IMachineTypeNameArgumentBuilder
{
    Argument<string> Build();
}

public class MachineTypeNameArgumentBuilder : IMachineTypeNameArgumentBuilder
{
    public Argument<string> Build()
    {
        return new Argument<string>("type", "MachineType Name");
    }
}