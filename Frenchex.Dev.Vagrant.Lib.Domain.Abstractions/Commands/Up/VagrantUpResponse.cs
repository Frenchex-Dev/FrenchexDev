﻿#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Up;

/// <summary>
/// </summary>
public class VagrantUpResponse(
    int exitCode
) : BaseVagrantCommandResponse(exitCode), IVagrantUpResponse;
