using Frenchex.Dev.Dotnet.Core.Filesystem.Lib.Domain;
using Frenchex.Dev.Dotnet.Core.UnitTesting.Lib.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.Dotnet.Core.Filesystem.Lib.Tests;

[TestClass]
public abstract class FilesystemCopyFileTests : AbstractUnitTest
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
    public async Task CanCopyFile(string originalFile)
    {
        await UnitTest!.ExecuteAndAssertAndCleanupAsync<ExecutionContext>(async (provider, root, context, vsCode) =>
            {
                var fs = provider.GetRequiredService<IFilesystem>();

                context.FullDestinationFile = Path.GetTempFileName();

                if (fs.FileExists(context.FullDestinationFile))
                {
                    fs.FileDelete(context.FullDestinationFile);
                }

                if (!fs.FileExists(originalFile))
                {
                    fs.FileCopy(Path.GetTempFileName(), originalFile);
                }

                await Task.Run(() =>
                {
                    fs.FileCopy(originalFile, context.FullDestinationFile);
                });
            },
            async (provider, root, context) =>
            {
                await Task.Run(() =>
                {
                    Assert.IsTrue(File.Exists(context.FullDestinationFile));
                });
            },
            async (provider, root, context) =>
            {
                await Task.Run(() =>
                {
                    var fileToDelete = context.FullDestinationFile;
                    File.Delete(fileToDelete!);
                });
            },
            UnitTest.ServiceProvider!
        );
    }

    public abstract class ExecutionContext : WithWorkingDirectoryExecutionContext
    {
        public string? FullDestinationFile { get; set; }

    }
}