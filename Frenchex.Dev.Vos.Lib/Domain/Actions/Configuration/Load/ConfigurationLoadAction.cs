using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Actions.Configuration.Load;
using Newtonsoft.Json;

namespace Frenchex.Dev.Vos.Lib.Domain.Actions.Configuration.Load;

public class ConfigurationLoadAction : IConfigurationLoadAction
{
    public async Task<Abstractions.Domain.Configuration.Configuration> Load(string path)
    {
        var loaded = await File.ReadAllTextAsync(path);

        var deserialized = new Abstractions.Domain.Configuration.Configuration();

        try
        {
            deserialized = JsonConvert.DeserializeObject<Abstractions.Domain.Configuration.Configuration>(loaded);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error while deserializing: {e.Message}");
        }

        if (null == deserialized) throw new ApplicationException("Error while deserializing");

        return deserialized;
    }
}