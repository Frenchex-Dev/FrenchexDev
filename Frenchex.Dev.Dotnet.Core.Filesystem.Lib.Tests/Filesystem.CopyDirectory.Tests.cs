using Frenchex.Dev.Dotnet.Core.Filesystem.Lib.Domain;
using Frenchex.Dev.Dotnet.Core.UnitTesting.Lib.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.Dotnet.Core.Filesystem.Lib.Tests;

[TestClass]
[TestCategory("component:filesystem")]
public class FilesystemCopyDirectoryTests : AbstractUnitTest
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
            {Path.Join(Directory.GetCurrentDirectory(), "Resources")};
    }

    [TestMethod]
    [DynamicData(nameof(DataSource), DynamicDataSourceType.Method)]
    public async Task CanCopyDirectory(string directoryToCopy)
    {
        await UnitTest!.ExecuteAndAssertAsync<ExecutionContext>(async (provider, _, context, _) =>
            {
                var fs = provider.GetRequiredService<IFilesystem>();

                context.DirectoryToCopy = directoryToCopy;
                context.Destination = Path.GetTempPath();

                await Task.Run(() =>
                {
                    fs.TryDirectoryDelete(context.Destination, true);
                    fs.DirectoryCopy(context.DirectoryToCopy!, context.Destination);
                });
            },
            async (_, _, context) =>
            {
                await Task.Run(() =>
                {
                    Assert.IsTrue(Directory.Exists(context.Destination));

                    var dirInfo = new DirectoryInfo(context.DirectoryToCopy!);

                    DirectoryInfo[] dirs = dirInfo.GetDirectories();

                    foreach (var dir in dirs)
                    {
                        Assert.IsTrue(Directory.Exists(dir.FullName));

                        foreach (var file in dir.GetFiles())
                        {
                            Assert.IsTrue(File.Exists(file.FullName));
                        }
                    }
                });
            },
            UnitTest.ServiceProvider!
        );
    }

    private class ExecutionContext : WithWorkingDirectoryExecutionContext
    {
        public string? DirectoryToCopy { get; set; }
        public string? Destination { get; set; }
    }
}