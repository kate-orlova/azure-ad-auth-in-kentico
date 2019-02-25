using System;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace AzureADAuthInKentico.Pages
{
    public partial class AzureAuthRedirect : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ClientCredential credential = new ClientCredential(Constants.AzureActiveDirectory.ClientId,
                Constants.AzureActiveDirectory.AppKey);

        }
    }
}