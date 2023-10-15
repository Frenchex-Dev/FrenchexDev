#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Init;
using Frenchex.Dev.Vagrant.Lib.Domain.Tests.Abstractions;
using Shouldly;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Tests.Commands.Init;

public class VagrantInitResponseBuilderTests : AbstractVagrantResponseBuilderTester
{
    protected static IEnumerable<object[]> InitData()
    {
        yield return new object[]
                     {
                         new Payload
                         {
                             ExitCode = 0
                           , StdErr   = new List<string>()
                           , StdOut   = new List<string>()
                           , ExpectedResponse = new VagrantInitResponse(0)
                         }
                     };

        yield return new object[]
                     {
                         new Payload
                         {
                             ExitCode = 0
                           , StdErr   = new List<string>()
                           , StdOut   = new List<string>()
                           , ExpectedResponse = new VagrantInitResponse(0)
                         }
                     };

        yield return new object[]
                     {
                         new Payload
                         {
                             ExitCode = 0
                           , StdErr   = new List<string>()
                           , StdOut   = new List<string>()
                           , ExpectedResponse = new VagrantInitResponse(0)
                         }
                     };
    }

    [Test] [TestCaseSource(nameof(InitData))]
    public async Task Init(
        Payload payload
    )
    {
        await ExecuteInternalAsync<IVagrantInitResponseBuilder, IVagrantInitResponse>(
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
