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

namespace Frenchex.Dev.Vos.Cli.Integration.Domain.Options;

public interface INetworkBridgeOptionBuilder
{
    Option<string> Build();
}

internal class NetworkBridgeOptionBuilder : INetworkBridgeOptionBuilder
{
    public Option<string> Build()
    {
        return new Option<string>(new[] { "--network-bridge" }, "Network Bridge");
    }
}