using System.Net.Http;
using System.Web;

namespace AzureADAuthInKentico.Extensions
{
    public static class UrlHelperExtensions
    {
        public static string GetReturnUrl(this HttpRequest request, string defaultUrl = "/")
        {
            var queryReturnUrl = request?.QueryString["returnurl"];
            if (queryReturnUrl != null)
            {
                return queryReturnUrl;
            }

            if (request?.UrlReferrer == null)
            {
                return defaultUrl;
            }

            var refererReturnUrl = HttpContext.Current.Request.UrlReferrer;
            var refererQuerystringReturnUrl = refererReturnUrl.ParseQueryString()["returnurl"];
            if (refererQuerystringReturnUrl.IsEmpty())
            {
                return defaultUrl;
            }

            return refererQuerystringReturnUrl;
        }
    }
}