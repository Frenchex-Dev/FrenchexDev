﻿#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Dotnet.Core.UnitTesting.Lib.Domain;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Frenchex.Dev.Packer.Lib.Tests.Domain.Facade;

[TestClass]
[TestCategory("component:packer")]
public class FacadeUnitTestingWorkflowsTests : AbstractUnitTest
{
    [TestInitialize]
    public void Setup()
    {
        UnitTest = PackerUnitTestBase.CreateUnitTest<ExecutionContext>();
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