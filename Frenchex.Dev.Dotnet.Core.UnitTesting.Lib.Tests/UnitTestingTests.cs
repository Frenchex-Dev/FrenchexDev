using Frenchex.Dev.Dotnet.Core.UnitTesting.Lib.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.Dotnet.Core.UnitTesting.Lib.Tests;

[TestClass]
public class UnitTestingTests
{
    [TestMethod]
    public async Task CanCreateUnitTestAndBuildAndExecute()
    {
        var executionContext = new ExecutionContext();

        var unitTest = new UnitTest(
            builder =>
            {
                executionContext.HasRanConfigureConfigurationFunction.Mark();
            },
            (services, root) =>
            {
                executionContext.HasRanConfigureServicesFunction.Mark();
            },
            (services, root) =>
            {
                executionContext.HasRanConfigureMocksFunction.Mark();
                services.AddScoped<ExecutionContext>();
            });

        await unitTest.ExecuteAndAssertAsync<ExecutionContext>((provider, root, context, vsCode) =>
            {
                executionContext.HasRanExecutionFunction.Mark();

                return Task.CompletedTask;
            },
            (provider, root, context) =>
            {
                executionContext.HasRanAssertFunction.Mark();

                return Task.CompletedTask;
            },
            unitTest.ServiceProvider!
        );

        var buildingOk =
            executionContext
                .HasRanConfigureConfigurationFunction
                .HasRanBefore(executionContext.HasRanConfigureServicesFunction)
            &&
            executionContext
                .HasRanConfigureServicesFunction
                .HasRanBefore(executionContext.HasRanConfigureMocksFunction);

        var executionOk = executionContext.HasRanExecutionFunction.HasRanBefore(executionContext.HasRanAssertFunction);

        Assert.IsTrue(buildingOk);
        Assert.IsTrue(executionOk);
    }

    internal class HasRanFunction
    {
        public double? Time { get; protected set; }

        public void Mark()
        {
            Time = DateTime.Now.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
        }

        public bool HasRanBefore(HasRanFunction functionWhichShouldHaveRanBefore)
        {
            var result = Time < functionWhichShouldHaveRanBefore.Time;
            return result;
        }
    }

    internal class ExecutionContext : WithWorkingDirectoryExecutionContext
    {
        public HasRanFunction HasRanConfigureConfigurationFunction { get; set; } = new();
        public HasRanFunction HasRanConfigureServicesFunction { get; set; } = new();
        public HasRanFunction HasRanConfigureMocksFunction { get; set; } = new();

        public HasRanFunction HasRanExecutionFunction { get; set; } = new();
        public HasRanFunction HasRanAssertFunction { get; set; } = new();
    }
}