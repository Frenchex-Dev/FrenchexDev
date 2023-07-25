#region Usings

using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Abstractions;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Init;

public class VagrantInitRequestBuilder : AbstractVagrantRequestBuilder, IVagrantInitRequestBuilder
{
    private string? _boxVersion;
    private bool    _force;
    private bool    _minimal;
    private string? _name;
    private string? _output;
    private string? _template;
    private string? _url;

    public VagrantInitRequest Build()
    {
        return new VagrantInitRequest(_name, _url, _boxVersion, _force, _minimal, _output, _template, BaseBuilder.Color
                                    , BaseBuilder.MachineReadable, BaseBuilder.Version, BaseBuilder.Debug
                                    , BaseBuilder.Timestamp, BaseBuilder.DebugTimestamp, BaseBuilder.NoTty
                                    , BaseBuilder.Help);
    }


    public IVagrantInitRequestBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public IVagrantInitRequestBuilder WithUrl(string url)
    {
        _url = url;
        return this;
    }

    public IVagrantInitRequestBuilder WithBoxVersion(string boxVersion)
    {
        _boxVersion = boxVersion;
        return this;
    }

    public IVagrantInitRequestBuilder WithForce(bool force)
    {
        _force = force;
        return this;
    }

    public IVagrantInitRequestBuilder WithMinimal(bool minimal)
    {
        _minimal = minimal;
        return this;
    }

    public IVagrantInitRequestBuilder WithOutput(string output)
    {
        _output = output;
        return this;
    }

    public IVagrantInitRequestBuilder WithTemplate(string template)
    {
        _template = template;
        return this;
    }
}
