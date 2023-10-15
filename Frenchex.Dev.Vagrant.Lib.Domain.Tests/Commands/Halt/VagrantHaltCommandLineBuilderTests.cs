#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Halt;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Halt;
using Frenchex.Dev.Vagrant.Lib.Domain.Tests.Abstractions;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Tests.Commands.Halt;

public class VagrantHaltCommandLineBuilderTests : AbstractVagrantCommandLineBuilderTester
{
    protected static IEnumerable<object[]> HaltData()
    {
        yield return new object[]
                     {
                         new VagrantHaltRequestBuilder()
                             .WithNameOrId("default")
                             .WithForce(true)
                             .Build()
                       , "halt --force default"
                     };

        yield return new object[]
                     {
                         new VagrantHaltRequestBuilder()
                             .WithNameOrId("default")
                             .Build()
                       , "halt default"
                     };
    }

    [Test] [TestCaseSource(nameof(HaltData))]
    public async Task Halt(
        VagrantHaltRequest request
      , string             expected
    )
    {
        await ExecuteInternalAsync<IVagrantHaltCommandLineBuilder, VagrantHaltRequest>(
                                                                                       expected
                                                                                     , builder =>
                                                                                           builder.BuildCommandLineArguments(request));
    }
}
