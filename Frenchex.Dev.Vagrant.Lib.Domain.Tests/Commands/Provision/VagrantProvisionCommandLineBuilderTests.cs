#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Provision;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Provision;
using Frenchex.Dev.Vagrant.Lib.Domain.Tests.Abstractions;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Tests.Commands.Provision;

public class VagrantProvisionCommandLineBuilderTests : AbstractVagrantCommandLineBuilderTester
{
    protected static IEnumerable<object[]> ProvisionData()
    {
        yield return new object[]
                     {
                         new VagrantProvisionRequestBuilder()
                             .Base()
                             .GetOwner<VagrantProvisionRequestBuilder>()
                             .Build()
                       , "provision"
                     };

        yield return new object[]
                     {
                         new VagrantProvisionRequestBuilder()
                             .WithProvisionWith("my-script1.sh")
                             .WithProvisionWith("my-script2.sh")
                             .WithNameOrId("default")
                             .Build()
                       , "provision default --provision-with my-script1.sh --provision-with my-script2.sh"
                     };
    }

    [Test] [TestCaseSource(nameof(ProvisionData))]
    public async Task Provision(
        VagrantProvisionRequest request
      , string                  expected
    )
    {
        await ExecuteInternalAsync<IVagrantProvisionCommandLineBuilder, VagrantProvisionRequest>(
                                                                                                 expected
                                                                                               , builder => builder
                                                                                                     .BuildCommandLineArguments(
                                                                                                                                request));
    }
}
