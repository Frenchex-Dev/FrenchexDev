namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Actions.Naming;

public interface IVexNameToVagrantNameConverter
{
    string[] ConvertAll(string[] names, string? workingDirectory, Abstractions.Domain.Configuration.Configuration configuration);
}