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

public interface IEnabled3dOptionBuilder
{
    Option<bool> Build();
}

public class Enabled3dOptionBuilder : IEnabled3dOptionBuilder
{
    public Option<bool> Build()
    {
        return new Option<bool>(new[] { "--enabled-3d", "-3" }, "Enable Machine Type");
    }
}