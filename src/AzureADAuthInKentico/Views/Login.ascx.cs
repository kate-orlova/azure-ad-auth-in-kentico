using System;
using CMS.PortalEngine.Web.UI;

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
        }
    }
}