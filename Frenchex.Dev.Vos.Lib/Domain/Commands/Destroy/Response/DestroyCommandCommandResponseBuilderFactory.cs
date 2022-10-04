﻿using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Destroy.Response;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Root.Response;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Destroy.Response;

public class DestroyCommandCommandResponseBuilderFactory : RootCommandResponseBuilderFactory, IDestroyCommandCommandResponseBuilderFactory
{
    public IDestroyCommandCommandResponseBuilder Build()
    {
        return new DestroyCommandCommandResponseBuilder();
    }
}