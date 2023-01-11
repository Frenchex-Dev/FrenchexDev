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

public interface IRamMbOptionBuilder
{
    Option<int> Build();
}

public class RamMbOptionBuilder : IRamMbOptionBuilder
{
    public Option<int> Build()
    {
        return new Option<int>(new[] { "--ram", "-r" }, () => 128, "RAM in MB");
    }
}