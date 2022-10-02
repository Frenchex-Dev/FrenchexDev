namespace Frenchex.Dev.Dotnet.Core.Process.Lib.Domain;

public static class TimeSpanStringConversion
{
    public static TimeSpan? ConvertToTimeSpan(string? timeSpan)
    {
        if (string.IsNullOrEmpty(timeSpan))
        {
            return null; // empty means inf
        }

        var l = timeSpan.Length - 1;
        var value = timeSpan.Substring(0, l);
        var type = timeSpan.Substring(l, 1);

        switch (type)
        {
            case "d": return TimeSpan.FromDays(double.Parse(value));
            case "h": return TimeSpan.FromHours(double.Parse(value));
            case "m": return TimeSpan.FromMinutes(double.Parse(value));
            case "s": return TimeSpan.FromSeconds(double.Parse(value));
            case "f": return TimeSpan.FromMilliseconds(double.Parse(value));
            case "z": return TimeSpan.FromTicks(long.Parse(value));
            default: return TimeSpan.FromDays(double.Parse(value));
        }
    }
}