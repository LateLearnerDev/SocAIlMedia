namespace Application.System;

public static class SystemTime
{
    private static DateTime? _date;

    public static DateTime Now => _date ?? DateTime.Now;
    public static DateTime UtcNow => _date ?? DateTime.UtcNow;

    public static DateTime Today => _date ?? DateTime.Today;

    public static void Set(DateTime customDateTime)
    {
        _date = customDateTime;
    }

    public static void Reset()
    {
        _date = null;
    }
}