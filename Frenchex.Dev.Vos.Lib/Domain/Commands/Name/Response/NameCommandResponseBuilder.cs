#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Name.Response;

#endregion

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Name.Response;

public class NameCommandResponseBuilder : INameCommandResponseBuilder
{
    private string[]? _names;

    public INameCommandResponse Build()
    {
        if (null == _names) throw new InvalidOperationException("Names is null");

        return new NameCommandResponse(_names);
    }

    public INameCommandResponseBuilder SetNames(string[] names)
    {
        _names = names;
        return this;
    }
}