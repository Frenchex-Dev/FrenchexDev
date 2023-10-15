#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.SshConfig;
using Frenchex.Dev.Vagrant.Lib.Domain.Tests.Abstractions;
using Shouldly;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Tests.Commands.SshConfig;

public class VagrantSshConfigResponseBuilderTests : AbstractVagrantResponseBuilderTester
{
    protected static IEnumerable<object[]> SshConfigData()
    {
        yield return new object[]
                     {
                         new Payload
                         {
                             ExitCode = 0
                           , StdErr   = new List<string>()
                           , StdOut   = new List<string>()
                           , ExpectedResponse = new VagrantSshConfigResponse(0)
                         }
                     };

        yield return new object[]
                     {
                         new Payload
                         {
                             ExitCode = 0
                           , StdErr   = new List<string>()
                           , StdOut   = new List<string>()
                           , ExpectedResponse = new VagrantSshConfigResponse(0)
                         }
                     };

        yield return new object[]
                     {
                         new Payload
                         {
                             ExitCode = 0
                           , StdErr   = new List<string>()
                           , StdOut   = new List<string>()
                           , ExpectedResponse = new VagrantSshConfigResponse(0)
                         }
                     };
    }

    [Test] [TestCaseSource(nameof(SshConfigData))]
    public async Task SshConfig(
        Payload payload
    )
    {
        await ExecuteInternalAsync<IVagrantSshConfigResponseBuilder, IVagrantSshConfigResponse>(
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
