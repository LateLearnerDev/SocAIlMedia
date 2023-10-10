namespace Application.System;

public static class SystemTime
{
    private static DateTime _date;

    public static DateTime Now => _date != DateTime.MinValue
        ? _date
        : DateTime.Now;

    public static void Set(DateTime customDateTime)
    {
        _date = customDateTime;
    }

    public static void Reset()
    {
        _date = DateTime.MinValue;
    }
}