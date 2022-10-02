using Frenchex.Dev.Dotnet.Core.Filesystem.Lib.Domain;
using Frenchex.Dev.Dotnet.Core.UnitTesting.Lib.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.Dotnet.Core.Filesystem.Lib.Tests;

[TestClass]
[TestCategory("component:filesystem")]
public class FilesystemWriteAllTextAsyncTests : AbstractUnitTest
{
    [TestInitialize]
    public void CreateUnitTest()
    {
        UnitTest = FilesystemUnitTestBase.CreateNewUnitTest<ExecutionContext>();
        UnitTest.BuildIfNecessary();
    }

    public static IEnumerable<object[]> DataSource()
    {
        yield return new object[]
            {"simple text\nto write", Path.GetTempFileName()};
    }

    [TestMethod]
    [DynamicData(nameof(DataSource), DynamicDataSourceType.Method)]
    public async Task CanWriteAllTextAsync(string textToWrite, string destination)
    {
        await UnitTest!.ExecuteAndAssertAsync<ExecutionContext>(async (provider, root, context, vsCode) =>
            {
                var fs = provider.GetRequiredService<IFilesystem>();

                context.TextToWrite = textToWrite;
                context.FileToRead = destination;

                await Task.Run(
                    async () => { await fs.FileWriteAllTextAsync(context.FileToRead!, context.TextToWrite); });
            },
            async (provider, root, context) =>
            {
                await Task.Run(async () =>
                {
                    Assert.AreEqual(
                        context.TextToWrite,
                        await File.ReadAllTextAsync(context.FileToRead!)
                    );
                });
            },
            UnitTest.ServiceProvider!
        );
    }

    public class ExecutionContext : WithWorkingDirectoryExecutionContext
    {
        public string? FileToRead { get; set; }
        public string? TextToWrite { get; set; }
    }
}