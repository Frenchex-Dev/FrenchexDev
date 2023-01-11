#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Request;

#endregion

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Up.Request;

public interface IUpCommandRequestBuilder : IRootCommandRequestBuilder
{
    IUpCommandRequest Build();
    IUpCommandRequestBuilder UsingNames(string[] namesOrIds);
    IUpCommandRequestBuilder WithProvision(bool with);
    IUpCommandRequestBuilder UsingProvisionWith(string[] provisionWith);
    IUpCommandRequestBuilder WithDestroyOnError(bool with);
    IUpCommandRequestBuilder WithParallel(bool with);
    IUpCommandRequestBuilder UsingProvider(string provider);
    IUpCommandRequestBuilder WithInstallProvider(bool with);
    IUpCommandRequestBuilder WithParallelWorkers(int workers);
    IUpCommandRequestBuilder WithParallelWait(int wait);
}