#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Build.Command;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Build.Request;

#endregion

namespace Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Build.Facade;

public interface
    IBuildCommandFacade : IFacade<IBuildCommand, IBuildCommandRequestBuilderFactory, IBuildCommandRequestBuilder>
{
}