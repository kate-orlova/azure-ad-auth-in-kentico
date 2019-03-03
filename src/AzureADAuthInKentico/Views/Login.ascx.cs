using System;
using CMS.Helpers;
using CMS.PortalEngine.Web.UI;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace AzureADAuthInKentico.Views
{
    public partial class Login : CMSAbstractWebPart
    {
        public override void OnContentLoaded()
        {
            base.OnContentLoaded();
            SetupControl();
        }

        public override void ReloadData()
        {
            base.ReloadData();

            SetupControl();
        }

        protected async void SetupControl()
        {
            var authContext =
                new AuthenticationContext(string.Format(Constants.AzureActiveDirectory.Authority,
                    Constants.AzureActiveDirectory.TenantId));
            var authorizationUrl =
                await
                    authContext.GetAuthorizationRequestUrlAsync(
                        string.Format(Constants.AzureActiveDirectory.GraphResourceUri, ""),
                        Constants.AzureActiveDirectory.ClientId,
                        new Uri(URLHelper.GetAbsoluteUrl(Constants.AzureActiveDirectory.KenticoRedirectPage)),
                        UserIdentifier.AnyUser, null);
            btnAzureSignIn.NavigateUrl = authorizationUrl.AbsoluteUri;
        }
    }
}