#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Build.Command;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Build.Facade;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Build.Request;

#endregion

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Build.Facade;

internal class BuildCommandFacade : IBuildCommandFacade
{
    public BuildCommandFacade(IBuildCommand command, IBuildCommandRequestBuilderFactory requestBuilderFactory)
    {
        Command = command;
        RequestBuilderFactory = requestBuilderFactory;
    }

    public IBuildCommand Command { get; }
    public IBuildCommandRequestBuilderFactory RequestBuilderFactory { get; }
    public IBuildCommandRequestBuilder RequestBuilder => RequestBuilderFactory.Factory();
}