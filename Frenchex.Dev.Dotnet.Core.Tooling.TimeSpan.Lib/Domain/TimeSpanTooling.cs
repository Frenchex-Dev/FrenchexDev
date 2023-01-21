#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

namespace Frenchex.Dev.Dotnet.Core.Tooling.TimeSpan.Lib.Domain;

public class TimeSpanTooling : ITimeSpanTooling
{
    public System.TimeSpan? ConvertToTimeSpan(string? timeSpan)
    {
        if (string.IsNullOrEmpty(timeSpan)) return null;

        int l = timeSpan.Length - 1;
        string? value = timeSpan.Substring(0, l);
        string? type = timeSpan.Substring(l, 1);

        switch (type)
        {
            case "d": return System.TimeSpan.FromDays(double.Parse(value));
            case "h": return System.TimeSpan.FromHours(double.Parse(value));
            case "m": return System.TimeSpan.FromMinutes(double.Parse(value));
            case "s": return System.TimeSpan.FromSeconds(double.Parse(value));
            case "f": return System.TimeSpan.FromMilliseconds(double.Parse(value));
            case "z": return System.TimeSpan.FromTicks(long.Parse(value));
            default: return null;
        }
    }

    public int GetTotalMsConvertedToInt(string timeSpan, int? defaultValue = null)
    {
        var ts = ConvertToTimeSpan(timeSpan);

        if (ts is null)
        {
            if (defaultValue is null)
                throw new CannotParseString(timeSpan);
            return defaultValue.Value;
        }

        return (int)ts.Value.TotalMilliseconds;
    }
}

public class CannotParseString : Exception
{
    public CannotParseString(string timeSpan) : base($"Cannot parse {timeSpan} to TimeSpan")
    {
    }
}