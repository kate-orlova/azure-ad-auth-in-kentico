using System.Collections.Generic;
using System.Linq;
using AzureADAuthInKentico.Extensions;
using CMS.DataEngine;

namespace AzureADAuthInKentico.Constants
{
    public static class AzureActiveDirectory
    {
        public const string Authority = "https://login.microsoftonline.com/{0}";
        public const string GraphResourceUri = "https://graph.windows.net/{0}";
        public static string ClientId => SettingsKeyInfoProvider.GetValue("AzureClientId");
        public static string AppKey => SettingsKeyInfoProvider.GetValue("AzureApplicationKey");
        public static string TenantId => SettingsKeyInfoProvider.GetValue("AzureTenantId");
        public static List<string> GroupsToSync
            =>
                SettingsKeyInfoProvider.GetValue("AzureGroupsToSync")
                    .Split('\n')
                    .Select(x => x.TrimEnd('\r'))
                    .Where(x => x.IsNotEmpty())
                    .ToList();
    }
}