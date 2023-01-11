#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Dotnet.Core.Process.Lib.Domain.Process;
using Frenchex.Dev.Dotnet.Wrapping.Lib.Domain.Commands.Root;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Hcl2Upgrade.Response;

#endregion

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Hcl2Upgrade.Response;

public class Hcl2UpgradeCommandResponseBuilder : IHcl2UpgradeCommandResponseBuilder
{
    public IRootCommandResponseBuilder SetProcess(IProcess process)
    {
        throw new NotImplementedException();
    }

    public IRootCommandResponseBuilder SetProcessExecutionResult(ProcessExecutionResult processExecutionResult)
    {
        throw new NotImplementedException();
    }

    public IHcl2UpgradeCommandResponse Build()
    {
        throw new NotImplementedException();
    }
}