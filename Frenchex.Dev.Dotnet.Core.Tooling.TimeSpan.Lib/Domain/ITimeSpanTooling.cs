#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

namespace Frenchex.Dev.Dotnet.Core.Tooling.TimeSpan.Lib.Domain;

public interface ITimeSpanTooling
{
    public System.TimeSpan? ConvertToTimeSpan(string? timeSpan);
    public int GetTotalMsConvertedToInt(string timeSpan, int? defaultValue = null);
}