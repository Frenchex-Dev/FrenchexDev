#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

namespace Frenchex.Dev.Dotnet.Core.Solution.Lib.Domain.Base.Structure;

public class BasePathBasedActionWrapper
{
    private readonly Action<string> _wrappedAction;

    public BasePathBasedActionWrapper(Action<string> wrappedAction)
    {
        _wrappedAction = wrappedAction;
    }

    public void Generate(string basePath)
    {
        _wrappedAction.Invoke(basePath);
    }
}