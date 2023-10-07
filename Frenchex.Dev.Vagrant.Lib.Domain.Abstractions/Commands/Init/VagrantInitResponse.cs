#region Licensing

// Licensing please read LICENSE.md

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Init;

/// <summary>
/// </summary>
public class VagrantInitResponse(
    int exitCode
) : BaseVagrantCommandResponse(exitCode);
