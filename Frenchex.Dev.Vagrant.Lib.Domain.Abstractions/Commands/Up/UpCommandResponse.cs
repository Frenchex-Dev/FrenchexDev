#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Up;

/// <summary>
/// </summary>
public class UpCommandResponse(
    int exitCode
) : BaseVagrantCommandResponse(exitCode), IUpCommandResponse;