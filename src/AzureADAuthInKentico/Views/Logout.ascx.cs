using System;
using CMS.Helpers;
using CMS.Membership;
using CMS.PortalEngine.Web.UI;

namespace AzureADAuthInKentico.Views
{
    public partial class Logout : CMSAbstractWebPart
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnLogout_OnClick(object sender, EventArgs e)
        {
            AuthenticationHelper.SignOut();
            Response.Cache.SetNoStore();
            URLHelper.Redirect(CurrentDocument.AbsoluteURL);
        }
    }
}