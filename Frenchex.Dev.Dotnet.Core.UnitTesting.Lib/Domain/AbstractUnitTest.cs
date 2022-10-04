using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Frenchex.Dev.Dotnet.Core.UnitTesting.Lib.Domain;

[TestClass]
public abstract class AbstractUnitTest
{
    protected UnitTest? UnitTest;

    protected UnitTest GetUnitTest()
    {
        if (UnitTest is null)
        {
            throw new IllegalCallException();
        }

        return UnitTest;
    }
    
    [TestCleanup]
    public async Task InstanceCleanup()
    {
        if (UnitTest is not null)
        {
            await UnitTest.DisposeAsync();
        }
    }
}

public class IllegalCallException : Exception
{
    
}