#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.SshConfig.Response;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Root.Response;

#endregion

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.SshConfig.Response;

public class SshConfigCommandResponseBuilder : RootResponseBuilder, ISshConfigCommandResponseBuilder
{
    private string? _content;

    public ISshConfigCommandResponse Build()
    {
        return new SshConfigCommandResponse
        {
            Content = _content
        };
    }

    public ISshConfigCommandResponseBuilder WithContent(string content)
    {
        _content = content;
        return this;
    }
}