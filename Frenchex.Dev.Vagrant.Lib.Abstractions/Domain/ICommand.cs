#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Root.Request;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Root.Response;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Abstractions.Domain;

public interface ICommand<in TU, out TR>
    where TU : IRootCommandRequest
    where TR : IRootCommandResponse
{
    TR StartProcess(TU request);
}