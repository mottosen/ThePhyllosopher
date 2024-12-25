namespace ThePhyllosopherUmbraco.Utility
{
    public enum Month
    {
        January = 1,
        February = 2,
        March = 3,
        April = 4,
        May = 5,
        June = 6,
        July = 7,
        August = 8,
        September = 9,
        October = 10,
        November = 11,
        December = 12
    }

    public class DateTimeUtility
    {
        static public string MonthDay(DateTime dateTime) => $"{(Month)dateTime.Month} {dateTime.Day}";
        static public string MonthDayYear(DateTime dateTime) => $"{(Month)dateTime.Month} {dateTime.Day}, {dateTime.Year}";
    }
}
