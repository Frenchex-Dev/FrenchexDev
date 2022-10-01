using Frenchex.Dev.Dotnet.Core.Filesystem.Lib.Domain;
using Frenchex.Dev.Dotnet.Core.UnitTesting.Lib.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.Dotnet.Core.Filesystem.Lib.Tests;

[TestClass]
public class FilesystemDeleteFileTests : AbstractUnitTest
{
    [TestInitialize]
    public void CreateUnitTest()
    {
        UnitTest = FilesystemUnitTestBase.CreateNewUnitTest<ExecutionContext>();
    }

    public static IEnumerable<object[]> DataSource()
    {
        yield return new object[] {Path.Join("Resources", "file-to-copy.txt")};
    }

    [TestMethod]
    [DynamicData(nameof(DataSource), DynamicDataSourceType.Method)]
    public async Task CanDeleteFile(string fileToDelete)
    {
        await UnitTest!.ExecuteAndAssertAsync<ExecutionContext>(async (provider, root, context, vsCode) =>
            {
                var fs = provider.GetRequiredService<IFilesystem>();

                context.FileToDelete = fileToDelete;

                await Task.Run(() =>
                {
                    fs.FileDelete(context.FileToDelete);
                });
            },
            async (provider, root, context) =>
            {
                await Task.Run(() =>
                {
                    Assert.IsFalse(File.Exists(context.FileToDelete));
                });
            },
            UnitTest.ServiceProvider!
        );
    }

    public class ExecutionContext : WithWorkingDirectoryExecutionContext
    {
        public string? FileToDelete { get; set; }

    }
}