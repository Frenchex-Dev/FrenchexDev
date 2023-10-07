#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Abstractions;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Up;

public class VagrantUpCommandLineBuilder : AbstractVagrantCommandLineBuilder, IVagrantUpCommandLineBuilder
{
    public string BuildCommandLineArguments(
        VagrantUpRequest request
    )
    {
        return BuildArguments(GetCliCommandName(), request);
    }

    protected override string GetCliCommandName()
    {
        return "up";
    }

    protected override string BuildVagrantOptions(
        IVagrantCommandRequest request
    )
    {
        if (request is VagrantUpRequest upRequest)
        {
            var parts = new List<string>();

            if (!upRequest.Provision)
            {
                parts.Add("--no-provision");
            }

            if (upRequest.ProvisionWith.Length > 0)
            {
                parts.AddRange(upRequest.ProvisionWith);
            }

            if (upRequest.DestroyOnError)
            {
                parts.Add("--no-destroy-on-error");
            }

            if (upRequest.Parallel)
            {
                parts.Add("--parallel");
            }

            if (!string.IsNullOrEmpty(upRequest.Provider))
            {
                parts.Add($"--provider {upRequest.Provider}");
            }

            if (upRequest.InstallProvider)
            {
                parts.Add("--install-provider");
            }

            return string.Join(",", parts);
        }

        throw new NotImplementedException();
    }

    protected override string BuildVagrantArguments(
        IVagrantCommandRequest request
    )
    {
        if (request is VagrantUpRequest upRequest)
        {
            return upRequest.NameOrId;
        }

        throw new NotImplementedException();
    }
}