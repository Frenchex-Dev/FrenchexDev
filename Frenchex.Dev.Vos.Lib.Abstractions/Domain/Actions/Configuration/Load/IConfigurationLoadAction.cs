namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Actions.Configuration.Load;

public interface IConfigurationLoadAction
{
    Task<Abstractions.Domain.Configuration.Configuration> Load(string path);
}