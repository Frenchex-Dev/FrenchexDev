﻿using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Halt.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Halt.Request;

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Halt.Facade;

public interface IHaltCommandFacade : IFacableCommand,
    IFacade<IHaltCommand, IHaltCommandRequestBuilderFactory, IHaltCommandRequestBuilder>
{
}