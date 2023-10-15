#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Halt;
using Frenchex.Dev.Vagrant.Lib.Domain.Tests.Abstractions;
using Shouldly;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Tests.Commands.Halt;

public class VagrantHaltResponseBuilderTests : AbstractVagrantResponseBuilderTester
{
    protected static IEnumerable<object[]> HaltData()
    {
        yield return new object[]
                     {
                         new Payload
                         {
                             ExitCode = 0
                           , StdErr   = new List<string>()
                           , StdOut   = new List<string>()
                           , ExpectedResponse = new VagrantHaltResponse(0)
                         }
                     };

        yield return new object[]
                     {
                         new Payload
                         {
                             ExitCode = 0
                           , StdErr   = new List<string>()
                           , StdOut   = new List<string>()
                           , ExpectedResponse = new VagrantHaltResponse(0)
                         }
                     };

        yield return new object[]
                     {
                         new Payload
                         {
                             ExitCode = 0
                           , StdErr   = new List<string>()
                           , StdOut   = new List<string>()
                           , ExpectedResponse = new VagrantHaltResponse(0)
                         }
                     };
    }

    [Test] [TestCaseSource(nameof(HaltData))]
    public async Task Halt(
        Payload payload
    )
    {
        await ExecuteInternalAsync<IVagrantHaltResponseBuilder, IVagrantHaltResponse>(
                                                                                      async builder =>
                                                                                          await builder.BuildAsync(
                                                                                                                   payload.StdOut
                                                                                                                 , payload.StdErr
                                                                                                                 , payload.ExitCode)
                                                                                    , response =>
                                                                                      {
                                                                                          response.ShouldBeEquivalentTo(
                                                                                                                        payload
                                                                                                                            .ExpectedResponse);
                                                                                      });
    }
}
