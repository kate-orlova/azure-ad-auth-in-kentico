using CMS.DocumentEngine;
using CMS.DocumentEngine.Web.UI;
using CMS.SiteProvider;

namespace AzureADAuthInKentico.Extensions
{
    public static class TreeNodeExtensions
    {
        public static string GetRelativeUrl(this TreeNode node)
        {
            var siteName = SiteContext.CurrentSite.DomainName;
            var url = TransformationHelper.HelperObject.GetDocumentUrl(siteName, node.NodeAliasPath,
                node.DocumentUrlPath);

            return url;
        }
    }
}