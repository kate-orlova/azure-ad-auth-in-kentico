using CMS.DataEngine;

namespace AzureADAuthInKentico.Constants
{
    public static class AzureActiveDirectory
    {
        public const string Authority = "https://login.microsoftonline.com/{0}";
        public const string GraphResourceUri = "https://graph.windows.net/{0}";
        public static string ClientID => SettingsKeyInfoProvider.GetValue("AzureClientID");
        public static string AppKey => SettingsKeyInfoProvider.GetValue("AzureApplicationKey");
    }
}