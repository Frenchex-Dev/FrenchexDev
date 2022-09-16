using Frenchex.Dev.Vos.Cli.Integration.Domain.Options;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Root;

namespace Frenchex.Dev.Vos.Cli.Integration.Domain.Commands;

public class ABaseCommandIntegration
{
    protected readonly ITimeoutMsOptionBuilder TimeoutMsOptionBuilder;
    protected readonly IVagrantBinPathOptionBuilder VagrantBinPathOptionBuilder;
    protected readonly IWorkingDirectoryOptionBuilder WorkingDirectoryOptionBuilder;

    public ABaseCommandIntegration(
        IWorkingDirectoryOptionBuilder workingDirectoryOptionBuilder,
        ITimeoutMsOptionBuilder timeoutMsOptionBuilder,
        IVagrantBinPathOptionBuilder vagrantBinPathOptionBuilder
    )
    {
        WorkingDirectoryOptionBuilder = workingDirectoryOptionBuilder;
        TimeoutMsOptionBuilder = timeoutMsOptionBuilder;
        VagrantBinPathOptionBuilder = vagrantBinPathOptionBuilder;
    }

    protected static void BuildBase(IRootCommandRequestBuilder requestBuilder, CommandIntegrationPayload payload)
    {
        requestBuilder
            .BaseBuilder
            .WithDebug(true)
            .UsingWorkingDirectory(payload.WorkingDirectory)
            .UsingTimeoutMs(payload.TimeoutMs ?? 0)
            .UsingVagrantBinPath(payload.VagrantBinPath)
            ;
    }
}