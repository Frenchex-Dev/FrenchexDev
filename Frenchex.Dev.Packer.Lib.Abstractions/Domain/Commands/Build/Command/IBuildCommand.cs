#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Build.Request;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Build.Response;

#endregion

namespace Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Build.Command;

public interface IBuildCommand : IFacableCommand, ICommand<IBuildCommandRequest, IBuildCommandResponse>
{
}