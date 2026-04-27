namespace TravelAgency.Common;

public static class StringExtensions
{
    // метод розширення
    public static string ToTitleText(this string text)
    {
        return $"*** {text.ToUpper()} ***";
    }
}