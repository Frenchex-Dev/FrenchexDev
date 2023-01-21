#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Plugins.Request;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Plugins.Response;

#endregion

namespace Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Plugins.Command;

public interface IPluginsCommand : IFacableCommand,
    ICommand<IPluginsCommandRequest, IPluginsCommandResponse>
{
}