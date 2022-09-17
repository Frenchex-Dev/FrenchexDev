namespace Frenchex.Dev.Vos.Lib.Domain.Actions.Naming;

public interface IVexNameToVagrantNameConverter
{
    string[] ConvertAll(string[] names, string? workingDirectory, Domain.Configuration.Configuration configuration);
}