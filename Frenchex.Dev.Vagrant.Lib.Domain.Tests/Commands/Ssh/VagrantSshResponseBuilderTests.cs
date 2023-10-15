#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Ssh;
using Frenchex.Dev.Vagrant.Lib.Domain.Tests.Abstractions;
using Shouldly;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Tests.Commands.Ssh;

public class VagrantSshResponseBuilderTests : AbstractVagrantResponseBuilderTester
{
    protected static IEnumerable<object[]> SshData()
    {
        yield return new object[]
                     {
                         new Payload
                         {
                             ExitCode = 0
                           , StdErr   = new List<string>()
                           , StdOut   = new List<string>()
                           , ExpectedResponse = new VagrantSshResponse(0)
                         }
                     };

        yield return new object[]
                     {
                         new Payload
                         {
                             ExitCode = 0
                           , StdErr   = new List<string>()
                           , StdOut   = new List<string>()
                           , ExpectedResponse = new VagrantSshResponse(0)
                         }
                     };

        yield return new object[]
                     {
                         new Payload
                         {
                             ExitCode = 0
                           , StdErr   = new List<string>()
                           , StdOut   = new List<string>()
                           , ExpectedResponse = new VagrantSshResponse(0)
                         }
                     };
    }

    [Test] [TestCaseSource(nameof(SshData))]
    public async Task Ssh(
        Payload payload
    )
    {
        await ExecuteInternalAsync<IVagrantSshResponseBuilder, IVagrantSshResponse>(
                                                                                    async builder =>
                                                                                        await builder.BuildAsync(
                                                                                                                 payload.StdOut
                                                                                                               , payload.StdErr
                                                                                                               , payload.ExitCode)
                                                                                  , response =>
                                                                                    {
                                                                                        response.ShouldBeEquivalentTo(payload.ExpectedResponse);
                                                                                    });
    }
}
