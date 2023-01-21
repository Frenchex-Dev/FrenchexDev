#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Microsoft.VisualStudio.TestTools.UnitTesting;

#endregion

namespace Frenchex.Dev.Dotnet.Core.UnitTesting.Lib.Domain;

[TestClass]
public abstract class AbstractUnitTest
{
    protected UnitTest? UnitTest;

    protected UnitTest GetUnitTest()
    {
        return UnitTest ?? throw new ArgumentNullException(nameof(UnitTest));
    }

    [TestCleanup]
    public async Task InstanceCleanup()
    {
        if (UnitTest is not null) await UnitTest.DisposeAsync();
    }
}