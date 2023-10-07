﻿#region Licensing

// Licensing please read LICENSE.md

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Abstractions;

public interface IVagrantCommandLineBuilder<in TRequest> where TRequest : IVagrantCommandRequest
{
    string BuildCommandLineArguments(
        TRequest request
    );
}