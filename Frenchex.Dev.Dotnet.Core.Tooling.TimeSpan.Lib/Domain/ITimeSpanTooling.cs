namespace Frenchex.Dev.Dotnet.Core.Tooling.TimeSpan.Lib;

public interface ITimeSpanTooling
{
    public System.TimeSpan? ConvertToTimeSpan(string? timeSpan);
    public int GetTotalMsConvertedToInt(string timeSpan, int? defaultValue = null);
}