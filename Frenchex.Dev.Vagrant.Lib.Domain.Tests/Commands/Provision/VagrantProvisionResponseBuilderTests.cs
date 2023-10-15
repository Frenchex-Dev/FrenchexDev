#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Provision;
using Frenchex.Dev.Vagrant.Lib.Domain.Tests.Abstractions;
using Shouldly;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Tests.Commands.Provision;

public class VagrantProvisionResponseBuilderTests : AbstractVagrantResponseBuilderTester
{
    protected static IEnumerable<object[]> ProvisionData()
    {
        yield return new object[]
                     {
                         new Payload
                         {
                             ExitCode = 0
                           , StdErr   = new List<string>()
                           , StdOut   = new List<string>()
                           , ExpectedResponse = new VagrantProvisionResponse(0)
                         }
                     };

        yield return new object[]
                     {
                         new Payload
                         {
                             ExitCode = 0
                           , StdErr   = new List<string>()
                           , StdOut   = new List<string>()
                           , ExpectedResponse = new VagrantProvisionResponse(0)
                         }
                     };

        yield return new object[]
                     {
                         new Payload
                         {
                             ExitCode = 0
                           , StdErr   = new List<string>()
                           , StdOut   = new List<string>()
                           , ExpectedResponse = new VagrantProvisionResponse(0)
                         }
                     };
    }

    [Test] [TestCaseSource(nameof(ProvisionData))]
    public async Task Provision(
        Payload payload
    )
    {
        await ExecuteInternalAsync<IVagrantProvisionResponseBuilder, IVagrantProvisionResponse>(
                                                                                                async builder =>
                                                                                                    await builder.BuildAsync(
                                                                                                                             payload
                                                                                                                                 .StdOut
                                                                                                                           , payload
                                                                                                                                 .StdErr
                                                                                                                           , payload
                                                                                                                                 .ExitCode)
                                                                                              , response =>
                                                                                                {
                                                                                                    response.ShouldBeEquivalentTo(
                                                                                                                                  payload
                                                                                                                                      .ExpectedResponse);
                                                                                                });
    }
}
