namespace Frenchex.Dev.Vos.Lib.Domain.Actions.Configuration.Save;

public interface IConfigurationSaveAction
{
    Task Save(Domain.Configuration.Configuration configuration, string path);
}