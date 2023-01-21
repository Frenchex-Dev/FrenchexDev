#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Dotnet.Core.UnitTesting.Lib.Domain;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Tests.Domain.Facade;

[TestClass]
[TestCategory("component:vagrant")]
public class FacadeUnitTestingWorkflowsTests : AbstractUnitTest
{
    [TestInitialize]
    public void Setup()
    {
        UnitTest = VagrantUnitTestBase.CreateUnitTest<ExecutionContext>();
        UnitTest.BuildIfNecessary();
    }

    [TestMethod]
    public async Task CanLoadFacadeFromProvider()
    {
        await GetUnitTest().ExecuteAndAssertAsync<ExecutionContext>(
            async (provider, _, context, _) =>
            {
                await Task.Run(() => { context.Facade = provider.GetRequiredService<ICommandsFacade>(); });
            },
            async (_, _, context) =>
            {
                await Task.Run(() => { Assert.IsInstanceOfType(context.Facade, typeof(ICommandsFacade)); });
            },
            GetUnitTest().GetScopedServiceProvider(),
            new UnitTest.VsCodeDebugging { Open = false, TellMe = true }
        );
    }
}

internal class ExecutionContext : WithWorkingDirectoryExecutionContext
{
    public ICommandsFacade? Facade { get; set; }
}