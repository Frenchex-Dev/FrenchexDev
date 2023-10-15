#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Abstractions;

public class BaseVagrantCommandRequestBuilder(
    object owner
) : IBaseVagrantCommandRequestBuilder
{
    public bool  Color           { get; private set; } = true;
    public bool  MachineReadable { get; private set; }
    public bool  Version         { get; private set; }
    public bool  Help            { get; private set; }
    public bool  Debug           { get; private set; }
    public bool  Timestamp       { get; private set; }
    public bool  DebugTimestamp  { get; private set; }
    public bool? NoTty           { get; private set; } = false;

    public IBaseVagrantCommandRequestBuilder WithColor(
        bool withColor
    )
    {
        Color = withColor;
        return this;
    }

    public IBaseVagrantCommandRequestBuilder WithMachineReadable(
        bool withMachineReadable
    )
    {
        MachineReadable = withMachineReadable;
        return this;
    }

    public IBaseVagrantCommandRequestBuilder WithVersion(
        bool withVersion
    )
    {
        Version = withVersion;
        return this;
    }

    public IBaseVagrantCommandRequestBuilder WithDebug(
        bool withDebug
    )
    {
        Debug = withDebug;
        return this;
    }

    public IBaseVagrantCommandRequestBuilder WithTimestamp(
        bool withTimestamp
    )
    {
        Timestamp = withTimestamp;
        return this;
    }

    public IBaseVagrantCommandRequestBuilder WithDebugTimestamp(
        bool withTimestamp
    )
    {
        DebugTimestamp = withTimestamp;
        return this;
    }

    public IBaseVagrantCommandRequestBuilder WithHelp(
        bool withHelp
    )
    {
        Help = withHelp;
        return this;
    }

    public IBaseVagrantCommandRequestBuilder WithNoTty(
        bool withNoTty
    )
    {
        NoTty = withNoTty;
        return this;
    }

    public T GetOwner<T>()
    {
        return (T)owner;
    }
}
