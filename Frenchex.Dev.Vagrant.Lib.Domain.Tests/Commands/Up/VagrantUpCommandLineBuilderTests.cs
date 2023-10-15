#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Up;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Up;
using Frenchex.Dev.Vagrant.Lib.Domain.Tests.Abstractions;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Tests.Commands.Up;

public class VagrantUpCommandLineBuilderTests : AbstractVagrantCommandLineBuilderTester
{
    protected static IEnumerable<object[]> UpData()
    {
        yield return new object[]
                     {
                         new VagrantUpRequestBuilder()
                             .WithNameOrId("default")
                             .Build()
                       , "up default"
                     };

        yield return new object[]
                     {
                         new VagrantUpRequestBuilder()
                             .WithNameOrId("default")
                             .WithProvision(false)
                             .Build()
                       , "up --no-provision default"
                     };
    }

    [Test] [TestCaseSource(nameof(UpData))]
    public async Task Up(
        VagrantUpRequest request
      , string           expected
    )
    {
        await ExecuteInternalAsync<IVagrantUpCommandLineBuilder, VagrantUpRequest>(
                                                                                   expected
                                                                                 , builder => builder
                                                                                       .BuildCommandLineArguments(request));
    }
}
