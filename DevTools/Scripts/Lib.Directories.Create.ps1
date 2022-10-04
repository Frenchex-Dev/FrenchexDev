param(
    [string] $Path,
    [string] $Namespace,
    [string] $Name
)

cd $Path
mkdir Command
cd Command

@"
namespace $Namespace

public class ${Name}Command : RootCommand, I${Name}Command
{

    public ${Name}Command() : base()
    {
        _configurationSaveAction = configurationSaveAction;
        _responseBuilderFactory = responseBuilderFactory;
    }

    public async Task<IDefineMachineAddCommandResponse> ExecuteAsync(IDefineMachineAddCommandRequest request)
    {
        if (null == request.DefinitionDeclaration.Name)
            throw new InvalidOperationException("request or definitionDeclaration or name is null");

        var configFilePath = Path.Join(request.Base.WorkingDirectory, "config.json");
        var config = await ConfigurationLoadAction.Load(configFilePath);

        config.Machines.Add(request.DefinitionDeclaration.Name, request.DefinitionDeclaration);

        await _configurationSaveAction.Save(config, configFilePath);

        return _responseBuilderFactory
            .Factory()
            .Build();
    }
}
"@ | out-file $"${Name}"

mkdir DependencyInjection
mkdir Facade
mkdir Request
mkdir Response
cd -
