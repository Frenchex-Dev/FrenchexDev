#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands;

public interface IFacableCommand
{
    string GetCliCommandName();
}