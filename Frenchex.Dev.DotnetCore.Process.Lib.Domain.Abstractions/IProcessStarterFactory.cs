#region Licensing

// Licensing please read LICENSE.md

#endregion

namespace Frenchex.Dev.DotnetCore.Process.Lib.Domain.Abstractions;

public interface IProcessStarterFactory
{
    IProcessStarter Factory();
}
