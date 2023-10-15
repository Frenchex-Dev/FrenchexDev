#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Up;
using Frenchex.Dev.Vagrant.Lib.Domain.Tests.Abstractions;
using Shouldly;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Tests.Commands.Up;

public class VagrantUpResponseBuilderTests : AbstractVagrantResponseBuilderTester
{
    protected static IEnumerable<object[]> UpData()
    {
        yield return new object[]
                     {
                         new Payload
                         {
                             ExitCode = 0
                           , StdErr   = new List<string>()
                           , StdOut   = new List<string>()
                           , ExpectedResponse = new VagrantUpResponse(0)
                         }
                     };

        yield return new object[]
                     {
                         new Payload
                         {
                             ExitCode = 0
                           , StdErr   = new List<string>()
                           , StdOut   = new List<string>()
                           , ExpectedResponse = new VagrantUpResponse(0)
                         }
                     };

        yield return new object[]
                     {
                         new Payload
                         {
                             ExitCode = 0
                           , StdErr   = new List<string>()
                           , StdOut   = new List<string>()
                           , ExpectedResponse = new VagrantUpResponse(0)
                         }
                     };
    }

    [Test] [TestCaseSource(nameof(UpData))]
    public async Task Up(
        Payload payload
    )
    {
        await ExecuteInternalAsync<IVagrantUpResponseBuilder, IVagrantUpResponse>(
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
