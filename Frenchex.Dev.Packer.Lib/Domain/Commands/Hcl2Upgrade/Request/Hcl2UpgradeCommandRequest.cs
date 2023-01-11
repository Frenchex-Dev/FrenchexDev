#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Dotnet.Wrapping.Lib.Domain.Commands.Root;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Fmt.Request;

#endregion

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Hcl2Upgrade.Request;

public class Hcl2UpgradeCommandRequest : IHcl2UpgradeCommandRequest
{
    public Hcl2UpgradeCommandRequest(IBaseCommandRequest @base)
    {
        Base = @base;
    }

    public IBaseCommandRequest Base { get; }
}