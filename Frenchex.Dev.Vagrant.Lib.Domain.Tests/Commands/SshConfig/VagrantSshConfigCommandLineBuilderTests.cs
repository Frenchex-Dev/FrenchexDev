#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.SshConfig;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.SshConfig;
using Frenchex.Dev.Vagrant.Lib.Domain.Tests.Abstractions;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Tests.Commands.SshConfig;

public class VagrantSshConfigCommandLineBuilderTests : AbstractVagrantCommandLineBuilderTester
{
    protected static IEnumerable<object[]> SshConfigData()
    {
        yield return new object[]
                     {
                         new VagrantSshConfigRequestBuilder()
                             .Base()
                             .GetOwner<VagrantSshConfigRequestBuilder>()
                             .Build()
                       , "ssh-config"
                     };

        yield return new object[]
                     {
                         new VagrantSshConfigRequestBuilder()
                             .WithNameOrId("default")
                             .WithHost("my-host")
                             .Build()
                       , "ssh-config --host my-host default"
                     };
    }

    [Test] [TestCaseSource(nameof(SshConfigData))]
    public async Task SshConfig(
        VagrantSshConfigRequest request
      , string                  expected
    )
    {
        await ExecuteInternalAsync<IVagrantSshConfigCommandLineBuilder, VagrantSshConfigRequest>(
                                                                                                 expected
                                                                                               , builder => builder
                                                                                                     .BuildCommandLineArguments(
                                                                                                                                request));
    }
}
