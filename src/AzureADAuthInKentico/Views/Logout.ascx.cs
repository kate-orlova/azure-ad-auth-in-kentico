using System;
using CMS.Helpers;
using CMS.Membership;
using CMS.PortalEngine.Web.UI;

namespace AzureADAuthInKentico.Views
{
    public partial class Logout : CMSAbstractWebPart
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            EnableViewState = false;
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            if (StopProcessing) return;
        }

        protected void btnLogout_OnClick(object sender, EventArgs e)
        {
            AuthenticationHelper.SignOut();
            Response.Cache.SetNoStore();
            URLHelper.Redirect(CurrentDocument.AbsoluteURL);
        }
    }
}