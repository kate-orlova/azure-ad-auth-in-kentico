using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using AzureADAuthInKentico.Extensions;
using CMS.DataEngine;
using CMS.Helpers;
using CMS.Membership;
using CMS.SiteProvider;
using Microsoft.Azure.ActiveDirectory.GraphClient;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace AzureADAuthInKentico.Pages
{
    public partial class AzureAuthRedirect : System.Web.UI.Page
    {
        protected async void Page_Load(object sender, EventArgs e)
        {
            ClientCredential credential = new ClientCredential(Constants.AzureActiveDirectory.ClientId,
                Constants.AzureActiveDirectory.AppKey);
            var authContext =
                new AuthenticationContext(string.Format(Constants.AzureActiveDirectory.Authority,
                    Constants.AzureActiveDirectory.TenantId));
            var code = ValidationHelper.GetString(HttpContext.Current.Request.QueryString["code"], string.Empty);
            AuthenticationResult result =
                await
                    authContext.AcquireTokenByAuthorizationCodeAsync(code,
                        new Uri(Request.Url.GetLeftPart(UriPartial.Path)), credential,
                        string.Format(Constants.AzureActiveDirectory.GraphResourceUri, ""));
            var adClient = new ActiveDirectoryClient(
                new Uri(string.Format(Constants.AzureActiveDirectory.GraphResourceUri, result.TenantId)),
                async () => await GetAppTokenAsync(result.TenantId));
            var adUser =
                (User)
                await
                    adClient.Users.Where(x => x.UserPrincipalName.Equals(result.UserInfo.DisplayableId))
                        .Expand(x => x.MemberOf)
                        .ExecuteSingleAsync();
            var user =
                UserInfoProvider.GetUsers()
                    .Where("AzureADUsername", QueryOperator.Equals, adUser.UserPrincipalName)
                    .FirstOrDefault();
            var groupsToAdd = adUser.MemberOf.OfType<Group>()
                .Select(x => x.DisplayName)
                .Where(x => Constants.AzureActiveDirectory.GroupsToSync.Contains(x));
            var groupsToRemove = Constants.AzureActiveDirectory.GroupsToSync
                .Where(x => !groupsToAdd.Contains(x));
            if (user == null)
            {
                user = new CMS.Membership.UserInfo();
                user.UserName = adUser.UserPrincipalName;
                user.FirstName = adUser.GivenName;
                user.LastName = adUser.Surname;
                user.FullName = adUser.DisplayName;
                user.Email = adUser.Mail.IfEmpty(adUser.OtherMails.FirstOrDefault());
                user.SetValue("AzureADUsername", adUser.UserPrincipalName);
                user.IsExternal = true;
                user.Enabled = true;
                UserInfoProvider.SetUserInfo(user);
                UserInfoProvider.AddUserToSite(user.UserName, SiteContext.CurrentSiteName);
            }
        }

        private static async Task<string> GetAppTokenAsync(string tenantId)
        {
            AuthenticationContext authenticationContext =
                new AuthenticationContext(string.Format(Constants.AzureActiveDirectory.Authority, tenantId), false);
            ClientCredential clientCred = new ClientCredential(Constants.AzureActiveDirectory.ClientId,
                Constants.AzureActiveDirectory.AppKey);
            AuthenticationResult authenticationResult =
                await
                    authenticationContext.AcquireTokenAsync(
                        string.Format(Constants.AzureActiveDirectory.GraphResourceUri, ""), clientCred);
            return authenticationResult.AccessToken;
        }
    }
}