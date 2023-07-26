#region Usings

using Frenchex.Dev.Packer.Lib.Domain.Abstractions;

#endregion

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Abstractions;

public abstract class AbstractPackerCommandLineBuilder
{
    protected abstract string GetCliCommandName();

    protected abstract string BuildPackerOptions(
        IPackerCommandRequest request
    );

    protected abstract string BuildPackerArguments(
        IPackerCommandRequest request
    );
}

public abstract class AbstractPackerRequestBuilder
{
}

public abstract class AbstractPackerCommand
{
}
