#region Usings

using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Abstractions;

public abstract class AbstractVagrantCommandLineBuilder
{
    protected abstract string GetCliCommandName();

    protected static List<string> BuildRootVagrantOptions(IVagrantCommandRequest request)
    {
        var parts = new List<string>();

        if (!request.Color) parts.Add("--no-color");

        if (request.MachineReadable) parts.Add("--machine-readable");

        if (request.Version) parts.Add("--version");

        if (request.Debug) parts.Add("--debug");

        if (request.Timestamp) parts.Add("--timestamp");

        if (request.DebugTimestamp) parts.Add("--debug-timestamp");

        if (request.NoTty) parts.Add("no-tty");

        if (request.Help) parts.Add("--help");

        return parts;
    }

    protected string BuildArguments(
        string                 command
      , IVagrantCommandRequest request
      , bool                   vagrantArgumentsBefore = false
      , string                 extraArgs              = ""
    )
    {
        var parts = new List<string> { command };

        var options = BuildVagrantOptions(request);
        var args    = BuildVagrantArguments(request);

        if (vagrantArgumentsBefore)
        {
            if (!string.IsNullOrEmpty(args)) parts.Add(args);
            if (!string.IsNullOrEmpty(options)) parts.Add(options);
        }
        else
        {
            if (!string.IsNullOrEmpty(options)) parts.Add(options);
            if (!string.IsNullOrEmpty(args)) parts.Add(args);
        }

        if (!string.IsNullOrEmpty(extraArgs))
        {
            parts.Add("--");
            parts.Add(extraArgs);
        }

        return string.Join(" ", parts);
    }

    protected abstract string BuildVagrantOptions(IVagrantCommandRequest request);

    protected abstract string BuildVagrantArguments(IVagrantCommandRequest request);
}
