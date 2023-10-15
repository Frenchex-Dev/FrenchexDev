#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Status;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Status;
using Frenchex.Dev.Vagrant.Lib.Domain.Tests.Abstractions;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Tests.Commands.Status;

public class VagrantStatusCommandLineBuilderTests : AbstractVagrantCommandLineBuilderTester
{
    protected static IEnumerable<object[]> StatusData()
    {
        yield return new object[]
                     {
                         new VagrantStatusRequestBuilder()
                             .Base()
                             .GetOwner<VagrantStatusRequestBuilder>()
                             .Build()
                       , "status"
                     };

        yield return new object[]
                     {
                         new VagrantStatusRequestBuilder()
                             .WithNameOrId("default")
                             .Build()
                       , "status default"
                     };
    }

    [Test] [TestCaseSource(nameof(StatusData))]
    public async Task Status(
        VagrantStatusRequest request
      , string               expected
    )
    {
        await ExecuteInternalAsync<IVagrantStatusCommandLineBuilder, VagrantStatusRequest>(
                                                                                           expected
                                                                                         , builder =>
                                                                                               builder.BuildCommandLineArguments(
                                                                                                                                 request));
    }
}
