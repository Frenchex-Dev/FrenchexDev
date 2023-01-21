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

public class NameCommandResponseBuilderFactory : INameCommandResponseBuilderFactory
{
    public INameCommandResponseBuilder Factory()
    {
        return new NameCommandResponseBuilder();
    }
}