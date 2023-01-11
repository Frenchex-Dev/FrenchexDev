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
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Build.Request;
using RootCommandRequestBuilderFactory =
    Frenchex.Dev.Packer.Lib.Domain.Commands.Root.Request.RootCommandRequestBuilderFactory;

#endregion

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Build.Request;

public class BuildCommandRequestBuilderFactory : RootCommandRequestBuilderFactory, IBuildCommandRequestBuilderFactory
{
    public BuildCommandRequestBuilderFactory(IBaseCommandRequestBuilderFactory baseRequestBuilderFactory) : base(
        baseRequestBuilderFactory)
    {
    }

    public IBuildCommandRequestBuilder Factory()
    {
        return new BuildCommandRequestBuilder(BaseRequestBuilderFactory);
    }
}