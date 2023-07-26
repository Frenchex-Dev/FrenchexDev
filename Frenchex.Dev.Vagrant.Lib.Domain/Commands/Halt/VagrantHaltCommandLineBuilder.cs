#region Usings

using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Abstractions;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Halt;

public class VagrantHaltCommandLineBuilder : AbstractVagrantCommandLineBuilder, IVagrantHaltCommandLineBuilder
{
    public string BuildCommandLineArguments(
        VagrantHaltRequest request
    )
    {
        return BuildArguments(GetCliCommandName(), request);
    }

    protected override string GetCliCommandName()
    {
        return "halt";
    }

    protected override string BuildVagrantOptions(
        IVagrantCommandRequest request
    )
    {
        if (request is VagrantHaltRequest haltRequest)
        {
            var parts = new List<string>();

            if (haltRequest.Force) parts.Add("--force");

            return string.Join(",", parts);
        }

        throw new NotImplementedException();
    }

    protected override string BuildVagrantArguments(
        IVagrantCommandRequest request
    )
    {
        if (request is VagrantHaltRequest haltRequest)
        {
            var parts = new List<string>();

            if (!string.IsNullOrEmpty(haltRequest.NameOrId)) parts.Add(haltRequest.NameOrId);

            return string.Join(",", parts);
        }

        throw new NotImplementedException();
    }
}
