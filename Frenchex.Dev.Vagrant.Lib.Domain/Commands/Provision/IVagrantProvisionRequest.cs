﻿#region Usings

using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Provision;

public interface IVagrantProvisionRequest : IVagrantCommandRequest
{
    string   NameOrId      { get; }
    string[] ProvisionWith { get; }
}
