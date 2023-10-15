#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Init;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Init;
using Frenchex.Dev.Vagrant.Lib.Domain.Tests.Abstractions;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Tests.Commands.Init;

public class VagrantInitCommandLineBuilderTests : AbstractVagrantCommandLineBuilderTester
{
    protected static IEnumerable<object[]> InitData()
    {
        yield return new object[]
                     {
                         new VagrantInitRequestBuilder()
                             .WithName("generic/alpine317")
                             .WithForce(true)
                             .Build()
                       , "init --force generic/alpine317"
                     };

        yield return new object[]
                     {
                         new VagrantInitRequestBuilder()
                             .WithName("generic/alpine317")
                             .WithBoxVersion("4.2.14")
                             .WithForce(true)
                             .Build()
                       , "init --box-version 4.2.14 --force generic/alpine317"
                     };
    }

    [Test] [TestCaseSource(nameof(InitData))]
    public async Task Init(
        VagrantInitRequest request
      , string             expected
    )
    {
        await ExecuteInternalAsync<IVagrantInitCommandLineBuilder, VagrantInitRequest>(
                                                                                       expected
                                                                                     , builder =>
                                                                                           builder.BuildCommandLineArguments(request));
    }
}
