﻿#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Ssh;

public interface IVagrantSshRequestBuilder : IVagrantRequestBuilder<VagrantSshRequest>
{
    IVagrantSshRequestBuilder WithNameOrId(
        string nameOrId
    );

    IVagrantSshRequestBuilder WithCommand(
        string command
    );

    IVagrantSshRequestBuilder WithExtraSshArgs(
        string extraSshArgs
    );
}
