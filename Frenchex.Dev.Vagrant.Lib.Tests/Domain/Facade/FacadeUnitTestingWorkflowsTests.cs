using Frenchex.Dev.Dotnet.Core.UnitTesting.Lib.Domain;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.Vagrant.Lib.Tests.Domain.Facade;

[TestClass]
public class FacadeUnitTestingWorkflowsTests : AbstractUnitTest
{
    [TestInitialize]
    public static void Setup()
    {
        UnitTest = VagrantUnitTestBase.CreateUnitTest<ExecutionContext>();
        UnitTest.BuildIfNecessary();
    }
    
    /** @template.start 
    [TestMethod]
    public async Task Can()
    {
        await UnitTest!.RunAsync<ExecutionContext>(async (provider, root, context, vsCode) =>
            {
                await Task.Run(() =>
                {
                });
            },
            async (provider, root, context) =>
            {
                await Task.Run(() =>
                {
                });
            },
            async (provider, root, context) =>
            {
                await Task.Run(() =>
                {
                });
            },
            new UnitTest.VsCodeDebugging {Open = false, TellMe = true}
        );
    }
     **/

    [TestMethod]
    public async Task CanLoadFacadeFromProvider()
    {
        await UnitTest!.RunAsync<ExecutionContext>(async (provider, root, context, vsCode) =>
            {
                await Task.Run(() =>
                {
                    context.Facade = provider.GetRequiredService<ICommandsFacade>();
                });
            },
            async (provider, root, context) =>
            {
                await Task.Run(() =>
                {
                    Assert.IsInstanceOfType(context.Facade, typeof(ICommandsFacade));
                });
            },
            async (provider, root, context) =>
            {
                await Task.Run(() =>
                {
                });
            },
            new UnitTest.VsCodeDebugging {Open = false, TellMe = true}
        );
    }
}

public class ExecutionContext : WithWorkingDirectoryExecutionContext
{
    public ICommandsFacade? Facade { get; set; }
}