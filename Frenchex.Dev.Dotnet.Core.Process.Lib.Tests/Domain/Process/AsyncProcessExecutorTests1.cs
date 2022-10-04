using Frenchex.Dev.Dotnet.Core.Process.Lib.Domain.Process;
using Frenchex.Dev.Dotnet.Core.Process.Lib.Domain.ProcessBuilder;
using Frenchex.Dev.Dotnet.Core.UnitTesting.Lib.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.Dotnet.Core.Process.Lib.Tests.Domain.Process;

[TestClass]
[TestCategory("component:process")]
public class FilesystemCopyDirectoryTests : AbstractUnitTest
{
    [TestInitialize]
    public void CreateUnitTest()
    {
        UnitTest = ProcessUnitTestBase.CreateNewUnitTest<ExecutionContext>();
        UnitTest.BuildIfNecessary();
    }

    public static IEnumerable<object[]> DataSource()
    {
        yield return new object[]
            {"dotnet", "--help", "1s"};
    }

    [TestMethod]
    [DynamicData(nameof(DataSource), DynamicDataSourceType.Method)]
    public async Task CanBuildAndExecuteProcess(
        string binary,
        string arguments,
        string timeout
    )
    {
        await UnitTest!.ExecuteAndAssertAsync<ExecutionContext>(async (provider, root, context, vsCode) =>
            {
                var processBuilder = provider.GetRequiredService<IProcessBuilder>();

                var process = processBuilder.Build(new ProcessBuildingParameters(
                    binary,
                    arguments,
                    Path.GetTempPath(),
                    timeout,
                    false,
                    true,
                    true,
                    true,
                    true
                ));

                context.ProcessExecution = process.Start();

                context.OutputStream = new MemoryStream();
                context.OutputStreamWriter = new StreamWriter(context.OutputStream);

                context.ProcessExecution.Process.OutputDataReceived += async (_, e) =>
                {
                    if (e.Data != null)
                    {
                        await context.OutputStreamWriter.WriteLineAsync(e.Data);
                    }
                };

                await context!.ProcessExecution!.WaitForCompleteExit!;
                await context.OutputStreamWriter.FlushAsync();
                context.OutputStream.Position = 0;
                var outputReader = new StreamReader(context.OutputStream);
                context.Output = await outputReader.ReadToEndAsync();
            },
            (provider, root, context) =>
            {
                Assert.IsTrue(context!.ProcessExecution!.ExitCode == 0);
                Assert.IsTrue(context!.ProcessExecution!.Completed);
                Assert.IsTrue(!string.IsNullOrEmpty(context.Output));
                Assert.IsNotNull(context.ProcessExecution!.WaitForCompleteExit);

                return Task.CompletedTask;
            },
            UnitTest.ServiceProvider!);
    }

    private class ExecutionContext : WithWorkingDirectoryExecutionContext
    {
        public ProcessExecutionResult? ProcessExecution { get; set; }
        public MemoryStream? OutputStream { get; set; }
        public StreamWriter? OutputStreamWriter { get; set; }
        public string? Output { get; set; }
    }
}