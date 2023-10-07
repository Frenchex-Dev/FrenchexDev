#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Status;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Abstractions;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Status;

public class VagrantStatusCommandLineBuilder : AbstractVagrantCommandLineBuilder, IVagrantStatusCommandLineBuilder
{
    public string BuildCommandLineArguments(
        VagrantStatusRequest request
    )
    {
        return BuildArguments(GetCliCommandName(), request, false, string.Empty);
    }

    protected override string GetCliCommandName()
    {
        return "status";
    }

    protected override string BuildVagrantOptions(
        IVagrantCommandRequest request
    )
    {
        return string.Empty;
    }

    protected override string BuildVagrantArguments(
        IVagrantCommandRequest request
    )
    {
        if (request is VagrantStatusRequest statusRequest)
        {
            var parts = new List<string>();

            if (!string.IsNullOrEmpty(statusRequest.NameOrId)) parts.Add(statusRequest.NameOrId);

            return string.Join(" ", parts);
        }

        throw new NotImplementedException();
    }
}
