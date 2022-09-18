using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Init.Command;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Init.Facade;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Init.Request;

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Init.Facade;

class InitFacade : IInitFacade
{
    public IInitCommand Command { get; }
    public IInitCommandRequestBuilderFactory RequestBuilderFactory { get; }

    public IInitCommandRequestBuilder RequestBuilder => RequestBuilderFactory.Factory();
    
    public InitFacade(IInitCommand command, IInitCommandRequestBuilderFactory requestBuilderFactory)
    {
        Command = command;
        RequestBuilderFactory = requestBuilderFactory;
    }
}