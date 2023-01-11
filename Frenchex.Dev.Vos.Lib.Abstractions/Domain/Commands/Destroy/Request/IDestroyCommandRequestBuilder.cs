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

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Destroy.Request;

public interface IDestroyCommandRequestBuilder : IRootCommandRequestBuilder
{
    IDestroyCommandRequestBuilder UsingName(string? name);
    IDestroyCommandRequestBuilder WithForce(bool force);
    IDestroyCommandRequestBuilder WithParallel(bool parallel);
    IDestroyCommandRequestBuilder WithGraceful(bool graceful);
    IDestroyCommandRequestBuilder UsingDestroyTimeout(string timeout);
    IDestroyCommandRequest Build();
}