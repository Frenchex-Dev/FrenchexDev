#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Name.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Base.Request;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Root.Request;

#endregion

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Name.Request;

public class NameCommandCommandRequest : RootCommandRequest, INameCommandRequest
{
    public NameCommandCommandRequest(
        IBaseCommandRequest baseCommand,
        string[] names
    ) : base(baseCommand)
    {
        Names = names;
    }

    public string[] Names { get; }
}