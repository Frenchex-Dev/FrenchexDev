#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Ssh;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Abstractions;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Ssh;

public class VagrantSshCommandLineBuilder : AbstractVagrantCommandLineBuilder, IVagrantSshCommandLineBuilder
{
    public string BuildCommandLineArguments(
        VagrantSshRequest request
    )
    {
        return BuildArguments(GetCliCommandName(), request, false, request.ExtraSshArgs);
    }

    protected override string GetCliCommandName()
    {
        return "ssh";
    }

    protected override string BuildVagrantOptions(
        IVagrantCommandRequest request
    )
    {
        if (request is VagrantSshRequest sshRequest)
        {
            var parts = new List<string>();

            if (!string.IsNullOrEmpty(sshRequest.Command)) parts.Add($"--command \"{sshRequest.Command}\"");

            return string.Join(" ", parts);
        }

        throw new NotImplementedException();
    }

    protected override string BuildVagrantArguments(
        IVagrantCommandRequest request
    )
    {
        if (request is VagrantSshRequest sshRequest)
        {
            var parts = new List<string>();

            if (!string.IsNullOrEmpty(sshRequest.NameOrId)) parts.Add(sshRequest.NameOrId);

            return string.Join(" ", parts);
        }

        throw new NotImplementedException();
    }
}
