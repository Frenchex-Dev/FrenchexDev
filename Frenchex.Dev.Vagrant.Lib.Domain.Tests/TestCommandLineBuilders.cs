#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using FluentAssertions;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Destroy;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Halt;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Init;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Provision;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Ssh;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.SshConfig;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Status;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Destroy;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Halt;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Init;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Provision;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Ssh;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.SshConfig;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Status;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Up;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Tests;

[Parallelizable(ParallelScope.All)] public class TestCommandLineBuilders
{
    #region Internals

    protected async Task ExecuteInternal<TService, TRequest>(
        string                 expected
      , Func<TService, string> action
    ) where TService : IVagrantCommandLineBuilder<TRequest>
      where TRequest : IVagrantCommandRequest
    {
        #region Prepare

        var servicesBuilder = new ServiceCollection();

        ServicesConfigurator.Configure(servicesBuilder);

        var services = servicesBuilder.BuildServiceProvider(new ServiceProviderOptions
                                                            {
                                                                ValidateOnBuild = true
                                                              , ValidateScopes  = true
                                                            });

        await using var scope = services.CreateAsyncScope();

        var service = scope.ServiceProvider.GetRequiredService<TService>();

        #endregion

        #region Execute

        var builtCommandLine = action(service);

        #endregion

        #region Asserts

        builtCommandLine.Should()
                        .BeEquivalentTo(expected, "expected command line arguments generated");

        #endregion
    }

    #endregion

    #region Destroy

    protected static IEnumerable<object[]> DestroyData()
    {
        yield return new object[]
                     {
                         new VagrantDestroyRequestBuilder().WithNameOrId("default")
                                                           .WithForce(true)
                                                           .Build()
                       , "destroy --force default"
                     };

        yield return new object[]
                     {
                         new VagrantDestroyRequestBuilder().WithNameOrId("default")
                                                           .Build()
                       , "destroy default"
                     };

        yield return new object[]
                     {
                         new VagrantDestroyRequestBuilder().WithNameOrId("default")
                                                           .WithGraceful(true)
                                                           .Build()
                       , "destroy --graceful default"
                     };
    }

    [Test] [TestCaseSource(nameof(DestroyData))]
    public async Task Destroy(
        VagrantDestroyRequest request
      , string                expected
    )
    {
        await ExecuteInternal<IVagrantDestroyCommandLineBuilder, VagrantDestroyRequest>(expected
                                                                                      , builder => builder
                                                                                            .BuildCommandLineArguments(request));
    }

    #endregion

    #region Halt

    protected static IEnumerable<object[]> HaltData()
    {
        yield return new object[]
                     {
                         new VagrantHaltRequestBuilder().WithNameOrId("default")
                                                        .WithForce(true)
                                                        .Build()
                       , "halt --force default"
                     };

        yield return new object[]
                     {
                         new VagrantHaltRequestBuilder().WithNameOrId("default")
                                                        .Build()
                       , "halt default"
                     };
    }

    [Test] [TestCaseSource(nameof(HaltData))]
    public async Task Halt(
        VagrantHaltRequest request
      , string             expected
    )
    {
        await ExecuteInternal<IVagrantHaltCommandLineBuilder, VagrantHaltRequest>(expected
                                                                                , builder => builder
                                                                                      .BuildCommandLineArguments(request));
    }

    #endregion

    #region Init

    protected static IEnumerable<object[]> InitData()
    {
        yield return new object[]
                     {
                         new VagrantInitRequestBuilder().WithName("generic/alpine317")
                                                        .WithForce(true)
                                                        .Build()
                       , "init --force generic/alpine317"
                     };

        yield return new object[]
                     {
                         new VagrantInitRequestBuilder().WithName("generic/alpine317")
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
        await ExecuteInternal<IVagrantInitCommandLineBuilder, VagrantInitRequest>(expected
                                                                                , builder => builder
                                                                                      .BuildCommandLineArguments(request));
    }

    #endregion

    #region Provision

    protected static IEnumerable<object[]> ProvisionData()
    {
        yield return new object[]
                     {
                         new VagrantProvisionRequestBuilder().Base()
                                                             .GetOwner<VagrantProvisionRequestBuilder>()
                                                             .Build()
                       , "provision"
                     };

        yield return new object[]
                     {
                         new VagrantProvisionRequestBuilder().WithProvisionWith("my-script1.sh")
                                                             .WithProvisionWith("my-script2.sh")
                                                             .WithNameOrId("default")
                                                             .Build()
                       , "provision default --provision-with my-script1.sh --provision-with my-script2.sh"
                     };
    }

    [Test] [TestCaseSource(nameof(ProvisionData))]
    public async Task Provision(
        VagrantProvisionRequest request
      , string                  expected
    )
    {
        await ExecuteInternal<IVagrantProvisionCommandLineBuilder, VagrantProvisionRequest>(expected
                                                                                          , builder => builder
                                                                                                .BuildCommandLineArguments(request));
    }

    #endregion

    #region Ssh

    protected static IEnumerable<object[]> SshData()
    {
        yield return new object[]
                     {
                         new VagrantSshRequestBuilder().Base()
                                                       .GetOwner<VagrantSshRequestBuilder>()
                                                       .Build()
                       , "ssh"
                     };

        yield return new object[]
                     {
                         new VagrantSshRequestBuilder().WithNameOrId("default")
                                                       .Build()
                       , "ssh default"
                     };

        yield return new object[]
                     {
                         new VagrantSshRequestBuilder().WithNameOrId("default")
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
        await ExecuteInternal<IVagrantSshCommandLineBuilder, VagrantSshRequest>(expected
                                                                              , builder => builder
                                                                                    .BuildCommandLineArguments(request));
    }

    #endregion

    #region SshConfig

    protected static IEnumerable<object[]> SshConfigData()
    {
        yield return new object[]
                     {
                         new VagrantSshConfigRequestBuilder().Base()
                                                             .GetOwner<VagrantSshConfigRequestBuilder>()
                                                             .Build()
                       , "ssh-config"
                     };

        yield return new object[]
                     {
                         new VagrantSshConfigRequestBuilder().WithNameOrId("default")
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
        await ExecuteInternal<IVagrantSshConfigCommandLineBuilder, VagrantSshConfigRequest>(expected
                                                                                          , builder => builder
                                                                                                .BuildCommandLineArguments(request));
    }

    #endregion

    #region Status

    protected static IEnumerable<object[]> StatusData()
    {
        yield return new object[]
                     {
                         new VagrantStatusRequestBuilder().Base()
                                                          .GetOwner<VagrantStatusRequestBuilder>()
                                                          .Build()
                       , "status"
                     };

        yield return new object[]
                     {
                         new VagrantStatusRequestBuilder().WithNameOrId("default")
                                                          .Build()
                       , "status default"
                     };
    }

    [Test] [TestCaseSource(nameof(StatusData))]
    public async Task Status(
        VagrantStatusRequest request
      , string               expected
    )
    {
        await ExecuteInternal<IVagrantStatusCommandLineBuilder, VagrantStatusRequest>(expected
                                                                                    , builder => builder
                                                                                          .BuildCommandLineArguments(request));
    }

    #endregion

    #region Up

    protected static IEnumerable<object[]> UpData()
    {
        yield return new object[]
                     {
                         new VagrantUpRequestBuilder().WithNameOrId("default")
                                                      .Build()
                       , "up default"
                     };

        yield return new object[]
                     {
                         new VagrantUpRequestBuilder().WithNameOrId("default")
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
        await ExecuteInternal<IVagrantUpCommandLineBuilder, VagrantUpRequest>(expected
                                                                            , builder => builder
                                                                                  .BuildCommandLineArguments(request));
    }

    #endregion
}
