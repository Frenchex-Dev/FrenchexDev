#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

namespace Frenchex.Dev.Dotnet.Core.Solution.Lib.Domain.Base.Structure;

public class BasePathBasedFunctionReturningBoolWrapper
{
    private readonly Func<string, bool, bool> _wrapped;

    public BasePathBasedFunctionReturningBoolWrapper(Func<string, bool, bool> wrapped)
    {
        _wrapped = wrapped;
    }

    public bool Execute(string basePath, bool recursive = true)
    {
        return _wrapped.Invoke(basePath, recursive);
    }
}