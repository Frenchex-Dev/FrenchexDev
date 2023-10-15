#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Ssh;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Ssh;
using Frenchex.Dev.Vagrant.Lib.Domain.Tests.Abstractions;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Tests.Commands.Ssh;

public class VagrantSshCommandLineBuilderTests : AbstractVagrantCommandLineBuilderTester
{
    protected static IEnumerable<object[]> SshData()
    {
        yield return new object[]
                     {
                         new VagrantSshRequestBuilder()
                             .Base()
                             .GetOwner<VagrantSshRequestBuilder>()
                             .Build()
                       , "ssh"
                     };

        yield return new object[]
                     {
                         new VagrantSshRequestBuilder()
                             .WithNameOrId("default")
                             .Build()
                       , "ssh default"
                     };

        yield return new object[]
                     {
                         new VagrantSshRequestBuilder()
                             .WithNameOrId("default")
                             .WithCommand("echo 'hello world'")
                             .WithExtraSshArgs("--extra-ssh-args")
                             .Build()
                       , "ssh --command \"echo 'hello world'\" default -- --extra-ssh-args"
                     };
    }

    [Test] [TestCaseSource(nameof(SshData))]
    public async Task Ssh(
        VagrantSshRequest request
      , string            expected
    )
    {
        await ExecuteInternalAsync<IVagrantSshCommandLineBuilder, VagrantSshRequest>(
                                                                                     expected
                                                                                   , builder =>
                                                                                         builder.BuildCommandLineArguments(request));
    }
}
