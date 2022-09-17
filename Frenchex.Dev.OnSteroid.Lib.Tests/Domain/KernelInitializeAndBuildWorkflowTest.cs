using Frenchex.Dev.Dotnet.Core.UnitTesting.Lib.Domain;
using Frenchex.Dev.OnSteroid.Lib.DependencyInjection;
using Frenchex.Dev.OnSteroid.Lib.Domain.Kernel;
using Frenchex.Dev.OnSteroid.Lib.Domain.Workflows.Kernel;
using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.OnSteroid.Lib.Tests.Domain;

[TestClass]
public class KernelInitializeAndBuildWorkflowTest : AbstractUnitTest
{
    [TestInitialize]
    public void Setup()
    {
        UnitTest = OnSteroidLibUnitTestTest.CreateUnitTest<ExecutionContext>();
    }

    [TestCleanup]
    public async Task Cleanup()
    {
        await UnitTest!.DisposeAsync();
    }

    [TestMethod]
    public async Task CanFlow()
    {
        const string defaultScopeName = "default";

        await UnitTest!.RunAsync<ExecutionContext>(async (provider, root, context, vsCode) =>
            {
                var kernelBuilderFlow =
                    provider.GetRequiredService<IKernelInitializeAndBuildWorkflow>();

                var serviceCollection = new ServiceCollection();
                var servicesConfiguration = new ServicesConfiguration();
                var kernelConfiguration = new KernelConfiguration(servicesConfiguration);

                context.Kernel = await kernelBuilderFlow.FlowAsync(serviceCollection, kernelConfiguration);
                context.DefaultScope = await context.Kernel.CreateScopeAsync();
            },
            async (provider, root, context) =>
            {
                await Task.Run(() =>
                {
                    if (context.Kernel is null)
                    {
                        throw new InvalidProgramException();
                    }

                    var servedScoped = context.Kernel.Scopes[defaultScopeName];
                    Assert.AreEqual(context.DefaultScope, servedScoped, "Same scope");
                });
            },
            async (provider, root, context) =>
            {
                if (context.Kernel is null)
                {
                    throw new InvalidProgramException();
                }

                await context.Kernel.DisposeAsync();
            }
        );
    }
}

public class ExecutionContext : WithWorkingDirectoryExecutionContext
{
    public IKernel? Kernel { get; set; }
    public AsyncServiceScope DefaultScope { get; set; }
}