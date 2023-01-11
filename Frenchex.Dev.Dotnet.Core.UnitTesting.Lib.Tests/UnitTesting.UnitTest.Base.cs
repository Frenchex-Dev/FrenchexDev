#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Dotnet.Core.UnitTesting.Lib.Domain;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Frenchex.Dev.Dotnet.Core.UnitTesting.Lib.Tests;

public static class FilesystemUnitTestBase
{
    public static UnitTest CreateNewUnitTest<T>() where T : class
    {
        return new UnitTest(
            builder =>
            {
                // no need for a configuration
            },
            (services, root) => { },
            (services, root) => { services.AddScoped<T>(); });
    }
}