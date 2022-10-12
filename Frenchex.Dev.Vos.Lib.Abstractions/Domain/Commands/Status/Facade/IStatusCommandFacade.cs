﻿using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Status.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Status.Request;

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Status.Facade;

public interface IStatusCommandFacade : IFacableCommand,
    IFacade<IStatusCommand, IStatusCommandRequestBuilderFactory, IStatusCommandRequestBuilder>
{
}