using System;
using System.Threading.Tasks;
using System.Web;
using CMS.Helpers;
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
        }

        private static async Task<string> GetAppTokenAsync(string tenantId)
        {
            AuthenticationContext authenticationContext =
                new AuthenticationContext(string.Format(Constants.AzureActiveDirectory.Authority, tenantId), false);
            ClientCredential clientCred = new ClientCredential(Constants.AzureActiveDirectory.ClientId,
                Constants.AzureActiveDirectory.AppKey);
            return null;
        }
    }
}