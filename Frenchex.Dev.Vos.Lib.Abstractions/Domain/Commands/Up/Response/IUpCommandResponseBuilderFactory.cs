#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Response;

#endregion

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Up.Response;

public interface IUpCommandResponseBuilderFactory : IRootResponseBuilderFactory
{
    IUpCommandResponseBuilder Factory();
}