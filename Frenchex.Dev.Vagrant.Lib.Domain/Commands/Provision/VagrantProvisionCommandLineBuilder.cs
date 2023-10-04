#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Provision;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Abstractions;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Provision;

public class VagrantProvisionCommandLineBuilder : AbstractVagrantCommandLineBuilder, IVagrantProvisionCommandLineBuilder
{
    public string BuildCommandLineArguments(
        VagrantProvisionRequest request
    )
    {
        return BuildArguments(GetCliCommandName(), request, true);
    }

    protected override string GetCliCommandName()
    {
        return "provision";
    }

    protected override string BuildVagrantOptions(
        IVagrantCommandRequest request
    )
    {
        if (request is VagrantProvisionRequest provisionRequest)
        {
            var parts = new List<string>();

            if (provisionRequest.ProvisionWith.Length > 0)
                foreach (var provisionWith in provisionRequest.ProvisionWith)
                    parts.Add("--provision-with " + provisionWith);

            return string.Join(" ", parts);
        }

        throw new NotImplementedException();
    }

    protected override string BuildVagrantArguments(
        IVagrantCommandRequest request
    )
    {
        if (request is VagrantProvisionRequest provisionRequest)
        {
            var parts = new List<string>();

            if (!string.IsNullOrEmpty(provisionRequest.NameOrId)) parts.Add(provisionRequest.NameOrId);

            return string.Join(" ", parts);
        }

        throw new NotImplementedException();
    }
}
