#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Actions.Configuration.Load;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

#endregion

namespace Frenchex.Dev.Vos.Lib.Domain.Actions.Configuration.Load;

public class ConfigurationLoadAction : IConfigurationLoadAction
{
    private readonly ILogger<ConfigurationLoadAction> _logger;

    public ConfigurationLoadAction(ILogger<ConfigurationLoadAction> logger)
    {
        _logger = logger;
    }

    public async Task<Abstractions.Domain.Configuration.Configuration> Load(string path)
    {
        try
        {
            string? loaded = await File.ReadAllTextAsync(Path.Join(path, "config.json"));

            var deserialized = JsonConvert.DeserializeObject<Abstractions.Domain.Configuration.Configuration>(loaded,
                new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });

            if (null == deserialized) throw new ArgumentNullException(nameof(deserialized));

            return deserialized;
        }
        catch (Exception e)
        {
            _logger.LogError("Error while deserializing config.json", e);
            throw;
        }
    }
}