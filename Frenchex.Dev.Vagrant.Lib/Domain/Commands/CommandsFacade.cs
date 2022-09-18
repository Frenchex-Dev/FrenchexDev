using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands;

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands;

public class CommandsFacade : ICommandsFacade
{
    private readonly IEnumerable<IFaceableCommand> _faceableCommands;

    public CommandsFacade(
        IEnumerable<IFaceableCommand> faceableCommands
    )
    {
        _faceableCommands = faceableCommands;
    }
    
    public IFaceableCommand? GetCommandFace(string name)
    {
        return _faceableCommands.FirstOrDefault(x => x.GetCliCommandName() == name);
    }
}