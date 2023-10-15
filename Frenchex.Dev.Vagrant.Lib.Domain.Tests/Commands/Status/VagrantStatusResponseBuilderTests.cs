#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Status;
using Frenchex.Dev.Vagrant.Lib.Domain.Tests.Abstractions;
using Shouldly;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Tests.Commands.Status;

public class VagrantStatusResponseBuilderTests : AbstractVagrantResponseBuilderTester
{
    protected static IEnumerable<object[]> StatusData()
    {
        yield return new object[]
                     {
                         new Payload
                         {
                             ExitCode = 0
                           , StdErr   = new List<string>()
                           , StdOut   = new List<string>()
                           , ExpectedResponse = new VagrantStatusResponse(0)
                         }
                     };

        yield return new object[]
                     {
                         new Payload
                         {
                             ExitCode = 0
                           , StdErr   = new List<string>()
                           , StdOut   = new List<string>()
                           , ExpectedResponse = new VagrantStatusResponse(0)
                         }
                     };

        yield return new object[]
                     {
                         new Payload
                         {
                             ExitCode = 0
                           , StdErr   = new List<string>()
                           , StdOut   = new List<string>()
                           , ExpectedResponse = new VagrantStatusResponse(0)
                         }
                     };
    }

    [Test] [TestCaseSource(nameof(StatusData))]
    public async Task Status(
        Payload payload
    )
    {
        await ExecuteInternalAsync<IVagrantStatusResponseBuilder, IVagrantStatusResponse>(
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
