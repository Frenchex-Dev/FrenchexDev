#region Usings

using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Abstractions;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Init;

public interface IVagrantInitRequestBuilder : IVagrantRequestBuilder<VagrantInitRequest>
{
    IVagrantInitRequestBuilder WithName(string name);

    IVagrantInitRequestBuilder WithUrl(string url);

    IVagrantInitRequestBuilder WithBoxVersion(string boxVersion);

    IVagrantInitRequestBuilder WithForce(bool force);

    IVagrantInitRequestBuilder WithMinimal(bool minimal);

    IVagrantInitRequestBuilder WithOutput(string output);

    IVagrantInitRequestBuilder WithTemplate(string template);
}
