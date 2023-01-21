#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Dotnet.Wrapping.Lib.Domain.Commands.Root;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Inspect.Request;

#endregion

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Inspect.Request;

public class InspectCommandRequestBuilder : IInspectCommandRequestBuilder
{
    public InspectCommandRequestBuilder(IBaseCommandRequestBuilderFactory baseBuilderFactory)
    {
        BaseBuilder = baseBuilderFactory.Factory(this);
    }

    public IBaseCommandRequestBuilder BaseBuilder { get; }

    public IInspectCommandRequest Build()
    {
        throw new NotImplementedException();
    }
}