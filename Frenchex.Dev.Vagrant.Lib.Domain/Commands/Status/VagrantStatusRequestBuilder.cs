#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Status;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Abstractions;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Status
{
    public class VagrantStatusRequestBuilder : AbstractVagrantRequestBuilder, IVagrantStatusRequestBuilder
    {
        private string _nameOrId = string.Empty;

        public VagrantStatusRequest Build()
        {
            return new VagrantStatusRequest(
                                            _nameOrId
                                          , BaseBuilder.Color
                                          , BaseBuilder.MachineReadable
                                          , BaseBuilder.Version
                                          , BaseBuilder.Debug
                                          , BaseBuilder.Timestamp
                                          , BaseBuilder.DebugTimestamp
                                          , BaseBuilder.NoTty
                                          , BaseBuilder.Help);
        }

        public IVagrantStatusRequestBuilder WithNameOrId(
            string nameOrId
        )
        {
            _nameOrId = nameOrId;
            return this;
        }
    }
}
