#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.SshConfig;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Abstractions;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.SshConfig;

public class VagrantSshConfigCommandLineBuilder : AbstractVagrantCommandLineBuilder, IVagrantSshConfigCommandLineBuilder
{
    public string BuildCommandLineArguments(
        VagrantSshConfigRequest request
    )
    {
        return BuildArguments(GetCliCommandName(), request, false, string.Empty);
    }

    protected override string GetCliCommandName()
    {
        return "ssh-config";
    }

    protected override string BuildVagrantOptions(
        IVagrantCommandRequest request
    )
    {
        if (request is VagrantSshConfigRequest sshConfigRequest)
        {
            var parts = new List<string>();

            if (!string.IsNullOrEmpty(sshConfigRequest.Host)) parts.Add($"--host {sshConfigRequest.Host}");

            return string.Join(" ", parts);
        }

        throw new NotImplementedException();
    }

    protected override string BuildVagrantArguments(
        IVagrantCommandRequest request
    )
    {
        if (request is VagrantSshConfigRequest sshConfigRequest)
        {
            var parts = new List<string>();

            if (!string.IsNullOrEmpty(sshConfigRequest.NameOrId)) parts.Add(sshConfigRequest.NameOrId);

            return string.Join(" ", parts);
        }

        throw new NotImplementedException();
    }
}
