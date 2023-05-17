using Microsoft.AspNetCore.Http;
using System.Linq;
using TemplateFwExample.Shared.Helpers;

namespace TemplateFwExample.Utilities
{
    public static class UrlHelper
    {
        public static string GetCurrentUrlWithoutLang(HttpContext context)
        {
            string url = context.Request.Path;
            string queryString = "";
            if (context.Request.QueryString.HasValue)
            {
                var queryParams = System.Web.HttpUtility.ParseQueryString(context.Request.QueryString.ToString());
                queryParams.Remove("lang");
                queryString = string.Join("&", queryParams.Cast<string>().Select(e => e + "=" + queryParams[e]));
            }
            if (!string.IsNullOrEmpty(queryString))
            {
                url += "?" + queryString;
            }
            return url;
        }
        public static string AppendLanguageParameter(this string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                return url;
            }
            if (url.Contains("?"))
            {
                url += $"&lang={LocalizationsManager.GetLanguageCode()}";
            }
            else
            {

                url += $"?lang={LocalizationsManager.GetLanguageCode()}";
            }
            return url;

        }


    }
}