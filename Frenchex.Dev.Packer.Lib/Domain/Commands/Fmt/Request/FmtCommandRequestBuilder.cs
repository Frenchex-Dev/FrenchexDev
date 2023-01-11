#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Dotnet.Wrapping.Lib.Domain.Commands.Root;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Fmt.Request;

#endregion

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Fmt.Request;

public class FmtCommandRequestBuilder : IFmtCommandRequestBuilder
{
    public FmtCommandRequestBuilder(IBaseCommandRequestBuilder baseBuilder)
    {
        BaseBuilder = baseBuilder;
    }

    public IBaseCommandRequestBuilder BaseBuilder { get; }

    public IFmtCommandRequest Build()
    {
        return new FmtCommandRequest(BaseBuilder.Build());
    }
}