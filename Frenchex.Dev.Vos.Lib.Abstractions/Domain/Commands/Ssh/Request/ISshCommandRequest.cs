#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Request;

#endregion

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Ssh.Request;

public interface ISshCommandRequest : IRootCommandRequest
{
    string[] NamesOrIds { get; }
    string[] Commands { get; }
    bool Plain { get; }
    string ExtraSshArgs { get; }
}