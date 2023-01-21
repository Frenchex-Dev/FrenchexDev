#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Dotnet.Core.UnitTesting.Lib.Domain;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Frenchex.Dev.Dotnet.Core.UnitTesting.Lib.Tests;

[TestClass]
[TestCategory("component:unit-testing")]
public class UnitTestingTests
{
    [TestMethod]
    public async Task CanCreateUnitTestAndBuildAndExecute()
    {
        var executionContext = new ExecutionContext();

        var unitTest = new UnitTest(
            builder => { executionContext.HasRanConfigureConfigurationFunction.Mark(); },
            (services, root) => { executionContext.HasRanConfigureServicesFunction.Mark(); },
            (services, root) =>
            {
                executionContext.HasRanConfigureMocksFunction.Mark();
                services.AddScoped<ExecutionContext>();
            });

        unitTest.BuildIfNecessary();

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
            unitTest.GetScopedServiceProvider()
        );

        bool buildingOk =
            executionContext
                .HasRanConfigureConfigurationFunction
                .HasRanBefore(executionContext.HasRanConfigureServicesFunction)
            &&
            executionContext
                .HasRanConfigureServicesFunction
                .HasRanBefore(executionContext.HasRanConfigureMocksFunction);

        bool executionOk = executionContext.HasRanExecutionFunction.HasRanBefore(executionContext.HasRanAssertFunction);

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
            bool result = Time < functionWhichShouldHaveRanBefore.Time;
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