using System;

namespace TemplateFwExample.Utilities
{
    public static class FbUrls
    {
        public static class API
        {
            public static string RequestFormApiUrl = "{ServiceApiUrl}/fbform/request?Service={ServiceCode}";
            public static string FollowUpFormApiUrl = "{ServiceApiUrl}/fbform/followup/{RequestId}";
            public static string RequestDataApiUrl = "{ServiceApiUrl}/fbdata/requestdata/{RequestId}";
            public static string RequestFormTypesApiUrl = "{ServiceApiUrl}/fbform/formtypes?id={ServiceCode}";
        }
        public static class Controls
        {
            public static string HistoryLog = "{ServiceWebUrl}/CustomControls/HistoryLog?requestId={RequestId}";
            public static string RequestHeader = "{ServiceWebUrl}/CustomControls/RequestHeader?requestId={RequestId}";
        }

    }
    public class FBServiceExternalUrls
    {
        public string ServiceCode { get; set; }
        public string RequestCode { get; set; }
        public string LanguageCode { get; set; }
        public string ServiceApiUrl { get; set; }
        public string ServiceWebUrl { get; set; }
        public FBServiceExternalUrls(string serviceApiUrl, string serviceWebUrl, string serviceCode, string requestCode, string languageCode)
        {
            ServiceApiUrl = (serviceApiUrl.EndsWith('/')) ? serviceApiUrl.Remove(serviceApiUrl.Length - 1) : serviceApiUrl;
            ServiceWebUrl = (serviceWebUrl.EndsWith('/')) ? serviceWebUrl.Remove(serviceWebUrl.Length - 1) : serviceWebUrl;
            ServiceCode = serviceCode;
            RequestCode = requestCode;
            LanguageCode = languageCode;
        }
        public string PrepareExternalUrl(string url)
        {
            string newUrl = null;
            try
            {
                newUrl = url
                    .Replace("{ServiceApiUrl}", ServiceApiUrl)
                    .Replace("{ServiceWebUrl}", ServiceWebUrl)
                      .Replace("{RequestId}", RequestCode)
                      .Replace("{ServiceCode}", ServiceCode)
                      .Replace("{LanguageCode}", LanguageCode);
            }
            catch (Exception ex)
            {

                throw;
            }
            return newUrl;
        }
        public string GetExternalControlUrl(string url)
        {
            string newUrl = null;
            try
            {
                newUrl = url
                    .Replace("{ServiceWebUrl}", ServiceWebUrl)
                      .Replace("{RequestId}", RequestCode)
                      .Replace("{ServiceCode}", ServiceCode)
                      .Replace("{LanguageCode}", LanguageCode);
            }
            catch (Exception ex)
            {

                throw;
            }
            return newUrl;
        }
    }
}
