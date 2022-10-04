﻿using Frenchex.Dev.Dotnet.Core.Process.Lib.Domain.Process;
using Frenchex.Dev.Dotnet.Core.Wrapping.Lib.Abstractions.Domain.Commands.Root.Response;
using Frenchex.Dev.Dotnet.Wrapping.Lib.Domain.Commands.Root;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Build.Response;

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Build.Response;

public class BuildCommandResponseBuilder : IBuildCommandResponseBuilder
{
    private readonly IBuildCommandResponseBuilder _buildCommandResponseBuilder;

    public BuildCommandResponseBuilder(IBuildCommandResponseBuilder buildCommandResponseBuilder)
    {
        _buildCommandResponseBuilder = buildCommandResponseBuilder;
    }

    public IRootCommandResponseBuilder SetProcess(IProcess process)
    {
        throw new NotImplementedException();
    }

    public IRootCommandResponseBuilder SetProcessExecutionResult(ProcessExecutionResult processExecutionResult)
    {
        throw new NotImplementedException();
    }

    public IBuildCommandResponse Build()
    {
        return _buildCommandResponseBuilder.Build();
    }
}