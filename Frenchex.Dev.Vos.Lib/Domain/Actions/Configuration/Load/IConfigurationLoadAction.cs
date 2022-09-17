namespace Frenchex.Dev.Vos.Lib.Domain.Actions.Configuration.Load;

public interface IConfigurationLoadAction
{
    Task<Domain.Configuration.Configuration> Load(string path);
}