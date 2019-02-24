namespace AzureADAuthInKentico.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNotEmpty(this string value)
        {
            return !string.IsNullOrEmpty(value);
        }
    }
}