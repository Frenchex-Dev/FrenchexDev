#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Halt;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Abstractions;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Halt
{
    public class VagrantHaltRequestBuilder : AbstractVagrantRequestBuilder, IVagrantHaltRequestBuilder
    {
        private bool    _force;
        private string? _nameOrId;

        public VagrantHaltRequest Build()
        {
            return new VagrantHaltRequest(
                                          _nameOrId
                                        , _force
                                        , BaseBuilder.Color
                                        , BaseBuilder.MachineReadable
                                        , BaseBuilder.Version
                                        , BaseBuilder.Debug
                                        , BaseBuilder.Timestamp
                                        , BaseBuilder.DebugTimestamp
                                        , BaseBuilder.NoTty
                                        , BaseBuilder.Help);
        }

        public IVagrantHaltRequestBuilder WithNameOrId(
            string nameOrId
        )
        {
            _nameOrId = nameOrId;
            return this;
        }

        public IVagrantHaltRequestBuilder WithForce(
            bool force
        )
        {
            _force = force;
            return this;
        }
    }
}
