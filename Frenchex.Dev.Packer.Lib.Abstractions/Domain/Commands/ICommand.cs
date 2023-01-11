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

#endregion

namespace Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands;

public interface ICommand<in TU, out TR>
    where TU : IRootCommandRequest
    where TR : IRootCommandResponse
{
    TR StartProcess(TU request);
}