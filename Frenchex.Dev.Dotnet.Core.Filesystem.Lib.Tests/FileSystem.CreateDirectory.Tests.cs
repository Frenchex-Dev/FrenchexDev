#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Dotnet.Core.Filesystem.Lib.Domain;
using Frenchex.Dev.Dotnet.Core.UnitTesting.Lib.Domain;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Frenchex.Dev.Dotnet.Core.Filesystem.Lib.Tests;

[TestClass]
[TestCategory("component:filesystem")]
public class FileSystemCreateDirectoryTests : AbstractUnitTest
{
    [TestInitialize]
    public void CreateUnitTest()
    {
        UnitTest = FilesystemUnitTestBase.CreateNewUnitTest<ExecutionContext>();
        GetUnitTest().BuildIfNecessary();
    }

    public static IEnumerable<object[]> DataSource()
    {
        yield return new object[] { Path.Join("Resources") };
    }

    [TestMethod]
    [DynamicData(nameof(DataSource), DynamicDataSourceType.Method)]
    public async Task CanCreateDirectory(string originalFile)
    {
        await GetUnitTest()
            .ExecuteAndAssertAndCleanupAsync<ExecutionContext>(
                async (provider, _, context, _) =>
                {
                    var fs = provider.GetRequiredService<IFilesystem>();

                    var originalFileName = Path.GetFileName(originalFile);
                    context.FullDestinationDirectory = Path.Join(Path.GetTempPath(), originalFileName);

                    await Task.Run(() => { fs.DirectoryCreate(context.FullDestinationDirectory); });
                },
                async (_, _, context) =>
                {
                    await Task.Run(() => { Assert.IsTrue(Directory.Exists(context.FullDestinationDirectory)); });
                },
                async (_, _, context) =>
                {
                    await Task.Run(() =>
                    {
                        var fileToDelete = context.FullDestinationDirectory;
                        Directory.Delete(fileToDelete!, true);
                    });
                },
                GetUnitTest().GetScopedServiceProvider()
            );
    }

    private class ExecutionContext : WithWorkingDirectoryExecutionContext
    {
        public string? FullDestinationDirectory { get; set; }
    }
}