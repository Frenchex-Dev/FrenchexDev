#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

namespace Frenchex.Dev.Dotnet.Core.Solution.Lib.Domain.Base.Structure;

public class FilesGenerator : BasePathBasedActionWrapper
{
    public FilesGenerator(Action<string> wrappedAction) : base(wrappedAction)
    {
    }
}