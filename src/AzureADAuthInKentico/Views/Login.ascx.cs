using System;
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

        protected void SetupControl()
        {
            var authContext =
                new AuthenticationContext(string.Format(Constants.AzureActiveDirectory.Authority,
                    Constants.AzureActiveDirectory.TenantId));
        }
    }
}