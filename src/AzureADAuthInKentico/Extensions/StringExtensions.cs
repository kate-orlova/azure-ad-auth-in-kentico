namespace AzureADAuthInKentico.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNotEmpty(this string value)
        {
            return !string.IsNullOrEmpty(value);
        }
        public static string IfEmpty(this string value, string emptyResult)
        {
            return string.IsNullOrEmpty(value) ? emptyResult : value;
        }
        public static bool IsEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }
    }
}