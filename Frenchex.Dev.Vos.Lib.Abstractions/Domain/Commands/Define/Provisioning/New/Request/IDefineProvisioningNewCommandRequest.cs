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
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Definitions;

#endregion

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Provisioning.New.Request;

public interface IDefineProvisioningNewCommandRequest : IRootCommandRequest
{
    string Name { get; }
    IDictionary<string, string> Env { get; }
    string[] Code { get; }
    OsTypeEnum Os { get; }
}