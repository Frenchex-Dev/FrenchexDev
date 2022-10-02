using Frenchex.Dev.Dotnet.Core.Filesystem.Lib.Domain;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Actions.Configuration.Save;
using Newtonsoft.Json;

namespace Frenchex.Dev.Vos.Lib.Domain.Actions.Configuration.Save;

public class ConfigurationSaveAction : IConfigurationSaveAction
{
    private readonly IFilesystem _fileSystemOperator;

    public ConfigurationSaveAction(
        IFilesystem fileSystem
    )
    {
        _fileSystemOperator = fileSystem;
    }

    public async Task Save(Abstractions.Domain.Configuration.Configuration configuration, string path)
    {
        var serialized = JsonConvert.SerializeObject(configuration,
            Formatting.Indented,
            new JsonSerializerSettings {
                NullValueHandling = NullValueHandling.Ignore
            });

        await _fileSystemOperator.FileWriteAllTextAsync(path, serialized);
    }
}