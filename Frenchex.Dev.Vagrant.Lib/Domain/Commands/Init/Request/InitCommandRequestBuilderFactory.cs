#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Init.Request;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Root.Base.Request;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Root.Request;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Init.Request;

public class InitCommandRequestBuilderFactory : RootCommandRequestBuilderFactory, IInitCommandRequestBuilderFactory
{
    public InitCommandRequestBuilderFactory(
        IBaseCommandRequestBuilderFactory baseRequestBuilderFactory
    ) : base(baseRequestBuilderFactory)
    {
    }

    public IInitCommandRequestBuilder Factory()
    {
        return new InitCommandRequestBuilder(BaseRequestBuilderFactory);
    }
}