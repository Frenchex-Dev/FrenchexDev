#region Usings

using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Abstractions;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Init;

public class VagrantInitCommandLineBuilder : AbstractVagrantCommandLineBuilder, IVagrantInitCommandLineBuilder
{
    public string BuildCommandLineArguments(VagrantInitRequest request)
    {
        return BuildArguments(GetCliCommandName(), request);
    }

    protected override string GetCliCommandName()
    {
        return "init";
    }

    protected override string BuildVagrantOptions(IVagrantCommandRequest request)
    {
        if (request is VagrantInitRequest initRequest)
        {
            var parts = new List<string>();

            if (!string.IsNullOrEmpty(initRequest.BoxVersion)) parts.Add($"--box-version {initRequest.BoxVersion}");

            if (initRequest.Force) parts.Add("--force");

            if (initRequest.Minimal) parts.Add("--minimal");

            if (!string.IsNullOrEmpty(initRequest.Output)) parts.Add($"--output {initRequest.Output}");

            if (!string.IsNullOrEmpty(initRequest.Template)) parts.Add($"--template {initRequest.Template}");

            parts.AddRange(BuildRootVagrantOptions(initRequest));

            return string.Join(" ", parts);
        }

        return string.Empty;
    }

    protected override string BuildVagrantArguments(IVagrantCommandRequest request)
    {
        if (request is VagrantInitRequest initRequest)
        {
            var parts = new List<string>();

            if (!string.IsNullOrEmpty(initRequest.Name)) parts.Add(initRequest.Name);

            if (!string.IsNullOrEmpty(initRequest.Url)) parts.Add(initRequest.Url);

            return string.Join(" ", parts);
        }

        return string.Empty;
    }
}
