#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Destroy;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Abstractions;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Destroy;

public class VagrantDestroyCommandLineBuilder : AbstractVagrantCommandLineBuilder, IVagrantDestroyCommandLineBuilder
{
    public string BuildCommandLineArguments(
        VagrantDestroyRequest request
    )
    {
        return BuildArguments(GetCliCommandName(), request);
    }

    protected override string GetCliCommandName()
    {
        return "destroy";
    }

    protected override string BuildVagrantOptions(
        IVagrantCommandRequest request
    )
    {
        if (request is VagrantDestroyRequest destroyRequest)
        {
            var parts = new List<string>();

            if (destroyRequest.Force)
            {
                parts.Add("--force");
            }

            if (destroyRequest.Parallel)
            {
                parts.Add("--parallel");
            }

            if (destroyRequest.Graceful)
            {
                parts.Add("--graceful");
            }

            return string.Join(",", parts);
        }

        throw new NotImplementedException();
    }

    protected override string BuildVagrantArguments(
        IVagrantCommandRequest request
    )
    {
        if (request is VagrantDestroyRequest destroyRequest)
        {
            var parts = new List<string>();

            if (!string.IsNullOrEmpty(destroyRequest.NameOrId))
            {
                parts.Add(destroyRequest.NameOrId);
            }

            return string.Join(",", parts);
        }

        throw new NotImplementedException();
    }
}