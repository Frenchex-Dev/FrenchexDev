using Frenchex.Dev.Dotnet.Core.Filesystem.Lib.Domain;
using Frenchex.Dev.Dotnet.Core.UnitTesting.Lib.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.Dotnet.Core.Filesystem.Lib.Tests;

[TestClass]
public class FilesystemFileExistsTests : AbstractUnitTest
{
    [TestInitialize]
    public void CreateUnitTest()
    {
        UnitTest = FilesystemUnitTestBase.CreateNewUnitTest<ExecutionContext>();
    }

    public static IEnumerable<object[]> DataSource()
    {
        yield return new object[] {Path.Join("Resources", "file-to-copy.txt"), true};
        yield return new object[] {Path.Join("Resources", "file-to-copy.txt"), false};
    }

    [TestMethod]
    [DynamicData(nameof(DataSource), DynamicDataSourceType.Method)]
    public async Task CanTestFileExists(string originalFile, bool shouldExist)
    {
        await UnitTest!.RunAsync<ExecutionContext>(async (provider, root, context, vsCode) =>
            {
                var fs = provider.GetRequiredService<IFilesystem>();

                context.FullDestinationFile = originalFile;
                context.FileShouldExists = shouldExist;

                await Task.Run(() =>
                {
                    context.FileExists = fs.FileExists(originalFile);
                });
            },
            async (provider, root, context) =>
            {
                await Task.Run(() =>
                {
                    // Assert.IsTrue(File.Exists(context.FullDestinationFile));
                });
            },
            async (provider, root, context) =>
            {
                await Task.Run(() =>
                {
                    var fileToDelete = context.FullDestinationFile;
                    File.Delete(fileToDelete!);
                });
            }
        );
    }

    public class ExecutionContext : WithWorkingDirectoryExecutionContext
    {
        public string? FullDestinationFile { get; set; }
        public bool? FileShouldExists { get; set; }
        public bool? FileExists { get; set; }
    }
}