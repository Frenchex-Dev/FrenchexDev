#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Destroy;
using Frenchex.Dev.Vagrant.Lib.Domain.Tests.Abstractions;
using Shouldly;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Tests.Commands.Destroy;

public class VagrantDestroyResponseBuilderTests : AbstractVagrantResponseBuilderTester
{
    public static IEnumerable<object[]> DestroyData()
    {
        yield return new object[]
                     {
                         new Payload
                         {
                             ExitCode         = 1
                           , StdErr           = new List<string>()
                           , StdOut           = new List<string>()
                           , ExpectedResponse = new VagrantDestroyResponse(1)
                         }
                     };

        yield return new object[]
                     {
                         new Payload
                         {
                             ExitCode         = 0
                           , StdErr           = new List<string>()
                           , StdOut           = new List<string>()
                           , ExpectedResponse = new VagrantDestroyResponse(0)
                         }
                     };

        yield return new object[]
                     {
                         new Payload
                         {
                             ExitCode         = 0
                           , StdErr           = new List<string>()
                           , StdOut           = new List<string>()
                           , ExpectedResponse = new VagrantDestroyResponse(0)
                         }
                     };
    }

    [Test] [TestCaseSource(nameof(DestroyData))]
    public async Task DestroyResponse(
        Payload payload
    )
    {
        await ExecuteInternalAsync<IVagrantDestroyResponseBuilder, IVagrantDestroyResponse>(
                                                                                            async builder =>
                                                                                                await builder.BuildAsync(
                                                                                                                         payload.StdOut
                                                                                                                       , payload.StdErr
                                                                                                                       , payload
                                                                                                                             .ExitCode)
                                                                                          , response =>
                                                                                            {
                                                                                                response.ShouldBeEquivalentTo(
                                                                                                                              payload
                                                                                                                                  .ExpectedResponse);
                                                                                            });
    }

    [Test] [TestCaseSource(nameof(DestroyData))]
    public async Task DestroyEventEmitter(
        Payload payload
    )
    {
        await ExecuteInternalAsync<IVagrantDestroyResponseBuilder, IVagrantDestroyResponse>(
                                                                                            async builder =>
                                                                                                await builder.BuildAsync(
                                                                                                                         payload.StdOut
                                                                                                                       , payload.StdErr
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
