﻿#region Licensing

// Licensing please read LICENSE.md

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Abstractions;

public interface IBaseVagrantCommandRequestBuilder
{
    IBaseVagrantCommandRequestBuilder WithColor(
        bool withColor
    );

    IBaseVagrantCommandRequestBuilder WithMachineReadable(
        bool withMachineReadable
    );

    IBaseVagrantCommandRequestBuilder WithVersion(
        bool withVersion
    );

    IBaseVagrantCommandRequestBuilder WithDebug(
        bool withDebug
    );

    IBaseVagrantCommandRequestBuilder WithTimestamp(
        bool withTimestamp
    );

    IBaseVagrantCommandRequestBuilder WithDebugTimestamp(
        bool withTimestamp
    );

    IBaseVagrantCommandRequestBuilder WithHelp(
        bool withHelp
    );

    IBaseVagrantCommandRequestBuilder WithNoTty(
        bool withNoTty
    );

    T GetOwner<T>();
}