#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Root.Base.Request;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Up.Request;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Up.Request;

public class UpCommandRequestBuilderFactory : IUpCommandRequestBuilderFactory
{
    private readonly IBaseCommandRequestBuilderFactory _baseFactory;

    public UpCommandRequestBuilderFactory(
        IBaseCommandRequestBuilderFactory baseRequestBuilderFactory
    )
    {
        _baseFactory = baseRequestBuilderFactory;
    }

    public IUpCommandRequestBuilder Factory()
    {
        return new UpCommandRequestBuilder(_baseFactory);
    }
}