﻿#region Usings

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Status;

public interface IVagrantStatusCommand : IVagrantCommand<VagrantStatusRequest, VagrantStatusResponse>
{
}