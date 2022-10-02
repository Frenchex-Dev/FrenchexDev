namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Actions.Configuration.Save;

public interface IConfigurationSaveAction
{
    Task Save(Abstractions.Domain.Configuration.Configuration configuration, string path);
}