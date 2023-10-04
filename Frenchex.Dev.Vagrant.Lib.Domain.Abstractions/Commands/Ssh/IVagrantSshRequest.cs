﻿#region Usings

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Ssh;

public interface IVagrantSshRequest : IVagrantCommandRequest
{
    string NameOrId     { get; }
    string ExtraSshArgs { get; }
    string Command      { get; }
}
