﻿#region Usings

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Halt;

/// <summary>
/// </summary>
public class VagrantHaltResponse(
    int exitCode
) : BaseVagrantCommandResponse(exitCode), IVagrantHaltResponse;
