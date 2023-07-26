#region Usings

using Frenchex.Dev.Packer.Lib.Domain.Abstractions;
using Frenchex.Dev.Packer.Lib.Domain.Commands.Abstractions;

#endregion

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Build;

public interface IPackerBuildCommand : IPackerCommand<PackerBuildRequest, PackerBuildResponse>
{
}

public class PackerBuildRequest : IPackerCommandRequest
{
}

public class PackerBuildResponse : IPackerCommandResponse
{
}

public interface IPackerBuildRequestBuilder : IPackerRequestBuilder<PackerBuildRequest>
{
}

public class PackerBuildRequestBuilder : AbstractPackerRequestBuilder, IPackerBuildRequestBuilder
{
    public PackerBuildRequest Build()
    {
        throw new NotImplementedException();
    }
}

public interface IPackerBuildCommandLineBuilder : IPackerCommandLineBuilder<PackerBuildRequest>
{
}

public class PackerBuildCommandLineBuilder : AbstractPackerCommandLineBuilder, IPackerBuildCommandLineBuilder
{
    public string BuildCommandLineArguments(
        PackerBuildRequest request
    )
    {
        throw new NotImplementedException();
    }

    protected override string GetCliCommandName()
    {
        return "build";
    }

    protected override string BuildPackerOptions(
        IPackerCommandRequest request
    )
    {
        throw new NotImplementedException();
    }

    protected override string BuildPackerArguments(
        IPackerCommandRequest request
    )
    {
        throw new NotImplementedException();
    }
}
