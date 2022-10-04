using Frenchex.Dev.Dotnet.Core.Filesystem.Lib.Domain;
using Frenchex.Dev.Dotnet.Core.UnitTesting.Lib.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.Dotnet.Core.Filesystem.Lib.Tests;

[TestClass]
[TestCategory("component:filesystem")]
public class FilesystemDirectoryExistsTests : AbstractUnitTest
{
    [TestInitialize]
    public void CreateUnitTest()
    {
        UnitTest = FilesystemUnitTestBase.CreateNewUnitTest<ExecutionContext>();
        UnitTest.BuildIfNecessary();
    }

    public static IEnumerable<object[]> DataSource()
    {
        yield return new object[] {Environment.CurrentDirectory};
    }

    [TestMethod]
    [DynamicData(nameof(DataSource), DynamicDataSourceType.Method)]
    public async Task CanCopyFile(string directoryToTestExistence)
    {
        await GetUnitTest().ExecuteAndAssertAsync<ExecutionContext>(async (provider, _, context, _) =>
            {
                var fs = provider.GetRequiredService<IFilesystem>();

                context.DirectoryToTestExistence = directoryToTestExistence;

                await Task.Run(() =>
                {
                    context.DirectoryExists = fs.DirectoryExists(context.DirectoryToTestExistence);
                });
            },
            async (provider, root, context) =>
            {
                await Task.Run(() => { Assert.IsTrue(context.DirectoryExists); });
            },
            GetUnitTest().GetScopedServiceProvider()
        );
    }

    public class ExecutionContext : WithWorkingDirectoryExecutionContext
    {
        public string? DirectoryToTestExistence { get; set; }
        public bool? DirectoryExists { get; set; }
    }
}