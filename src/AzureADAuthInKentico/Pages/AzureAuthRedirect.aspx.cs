using System;
using System.Web;
using CMS.Helpers;
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


        }
    }
}