﻿#region Usings

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Status;

public interface IVagrantStatusRequest : IVagrantCommandRequest
{
    string NameOrId { get; }
}