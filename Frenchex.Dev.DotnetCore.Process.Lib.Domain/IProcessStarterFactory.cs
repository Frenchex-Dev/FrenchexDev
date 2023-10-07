#region Licensing

// Licensing please read LICENSE.md

#endregion

namespace Frenchex.Dev.DotnetCore.Process.Lib.Domain;

public interface IProcessStarterFactory
{
    IProcessStarter Factory();
}