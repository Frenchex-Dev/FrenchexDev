#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Plugins.Command;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Plugins.Request;

#endregion

namespace Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Plugins.Facade;

public interface IPluginsCommandFacade : IFacableCommand,
    IFacade<IPluginsCommand, IPluginsCommandRequestBuilderFactory, IPluginsCommandRequestBuilder>
{
}