#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Destroy;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Destroy;
using Frenchex.Dev.Vagrant.Lib.Domain.Tests.Abstractions;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Tests.Commands.Destroy;

public class VagrantDestroyCommandLineBuilderTests : AbstractVagrantCommandLineBuilderTester
{
    protected static IEnumerable<object[]> DestroyData()
    {
        yield return new object[]
                     {
                         new VagrantDestroyRequestBuilder()
                             .WithNameOrId("default")
                             .WithForce(true)
                             .Build()
                       , "destroy --force default"
                     };

        yield return new object[]
                     {
                         new VagrantDestroyRequestBuilder()
                             .WithNameOrId("default")
                             .Build()
                       , "destroy default"
                     };

        yield return new object[]
                     {
                         new VagrantDestroyRequestBuilder()
                             .WithNameOrId("default")
                             .WithGraceful(true)
                             .Build()
                       , "destroy --graceful default"
                     };
    }

    [Test] [TestCaseSource(nameof(DestroyData))]
    public async Task Destroy(
        VagrantDestroyRequest request
      , string                expected
    )
    {
        await ExecuteInternalAsync<IVagrantDestroyCommandLineBuilder, VagrantDestroyRequest>(
                                                                                             expected
                                                                                           , builder =>
                                                                                                 builder.BuildCommandLineArguments(
                                                                                                                                   request));
    }
}
