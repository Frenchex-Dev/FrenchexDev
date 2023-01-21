#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using System.CommandLine;
using System.CommandLine.Invocation;

#endregion

namespace Frenchex.Dev.Vos.Cli.Integration.Domain.Commands.Up;

public class UpCommandIntegrationPayloadBinder : IGenericBinder<UpCommandIntegrationPayload>
{
    private readonly Option<bool> _destroyOnError;
    private readonly Option<bool> _installProvider;
    private readonly Argument<string[]> _names;
    private readonly Option<bool> _parallel;
    private readonly Option<int> _parallelWait;
    private readonly Option<int> _parallelWorkers;
    private readonly Option<string> _provider;
    private readonly Option<bool> _provision;
    private readonly Option<string[]> _provisionWith;
    private readonly Option<string> _timeout;
    private readonly Option<string> _vagrantBinPath;
    private readonly Option<string> _workingDir;

    public UpCommandIntegrationPayloadBinder(
        Argument<string[]> names,
        Option<bool> provision,
        Option<string[]> provisionWith,
        Option<bool> destroyOnError,
        Option<bool> parallel,
        Option<int> parallelWorkers,
        Option<int> parallelWait,
        Option<string> provider,
        Option<bool> installProvider,
        Option<string> timeout,
        Option<string> workingDir,
        Option<string> vagrantBinPath
    )
    {
        _names = names;
        _provision = provision;
        _provisionWith = provisionWith;
        _destroyOnError = destroyOnError;
        _parallel = parallel;
        _parallelWorkers = parallelWorkers;
        _parallelWait = parallelWait;
        _provider = provider;
        _installProvider = installProvider;
        _timeout = timeout;
        _workingDir = workingDir;
        _vagrantBinPath = vagrantBinPath;
    }

    public UpCommandIntegrationPayload GetBoundValue(InvocationContext bindingContext)
    {
        return new UpCommandIntegrationPayload
        {
            DestroyOnError = bindingContext.ParseResult.GetValueForOption(_destroyOnError),
            InstallProvider = bindingContext.ParseResult.GetValueForOption(_installProvider),
            Names = bindingContext.ParseResult.GetValueForArgument(_names),
            ParallelWorkers = bindingContext.ParseResult.GetValueForOption(_parallelWorkers),
            ParallelWait = bindingContext.ParseResult.GetValueForOption(_parallelWait),
            Provider = bindingContext.ParseResult.GetValueForOption(_provider),
            Provision = bindingContext.ParseResult.GetValueForOption(_provision),
            ProvisionWith = bindingContext.ParseResult.GetValueForOption(_provisionWith),
            TimeoutString = bindingContext.ParseResult.GetValueForOption(_timeout),
            WorkingDirectory = bindingContext.ParseResult.GetValueForOption(_workingDir),
            VagrantBinPath = bindingContext.ParseResult.GetValueForOption(_vagrantBinPath)
        };
    }
}