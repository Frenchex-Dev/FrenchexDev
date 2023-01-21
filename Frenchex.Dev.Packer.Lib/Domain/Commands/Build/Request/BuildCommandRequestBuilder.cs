#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Dotnet.Wrapping.Lib.Domain.Commands.Root;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Build.Request;
using RootCommandRequestBuilder = Frenchex.Dev.Packer.Lib.Domain.Commands.Root.Request.RootCommandRequestBuilder;

#endregion

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Build.Request;

public class BuildCommandRequestBuilder : RootCommandRequestBuilder, IBuildCommandRequestBuilder
{
    public BuildCommandRequestBuilder(IBaseCommandRequestBuilderFactory? baseRequestBuilderFactory) : base(
        baseRequestBuilderFactory)
    {
    }

    public IBuildCommandRequest Build()
    {
        throw new NotImplementedException();
    }
}