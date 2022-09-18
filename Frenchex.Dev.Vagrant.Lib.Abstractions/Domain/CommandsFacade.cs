using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands;

namespace Frenchex.Dev.Vagrant.Lib.Abstractions.Domain;

public interface ICommandsFacade
{
    IFaceableCommand GetCommandFace(string name);
}