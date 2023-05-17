using Dashboard.Common.WebClientHelpers.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using RestSharp;
using Serilog;
using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using TemplateFwExample.Shared.Helpers;

namespace Dashboard.Common.WebClientHelpers
{
    public static class ExternalApiRequestUrlHelper
    {
        private static IServiceCollection _serviceProvider;
        public static IServiceCollection SetExternalApiConfigurations(this IServiceCollection serviceProvider)
        {
            _serviceProvider = serviceProvider;
            return serviceProvider;
        }

        #region RestClient Methods

        public static T Get<T>(string url, string token = null)
        {
            return SendRequest<T>(Method.GET, url, string.Empty, token);
        }

        public static T Delete<T>(string url, string token = null)
        { return SendRequest<T>(Method.DELETE, url, string.Empty, token); }

        public static T Post<T>(string url, object dto, string token = null)
        { return SendRequest<T>(Method.POST, url, JsonConvert.SerializeObject(dto), token); }

        public static T Put<T>(string url, object dto, string token = null)
        { return SendRequest<T>(Method.PUT, url, JsonConvert.SerializeObject(dto), token); }

        #endregion

        #region Async Methods

        public static async Task<T> GetAsync<T>(string url, string token = null)
        {
            var response = await SendRequestAsync(Method.GET, url, null, token);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = JsonConvert.DeserializeObject<T>(response.Content);
                return result;

            }
            return default(T);
        }

        public static async Task<T> PostAsync<T>(string url, object dto, string token = null)
        {
            var response = await SendRequestAsync(Method.POST, url, JsonConvert.SerializeObject(dto), token);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = JsonConvert.DeserializeObject<T>(response.Content);
                return result;

            }
            return default(T);
        }
        public static async Task<IRestResponse> SendPostRequestAsync(string url, object dto, string token = null)
        {
            var response = await SendRequestAsync(Method.POST, url, JsonConvert.SerializeObject(dto), token);
            return response;
        }
        public static Task<IRestResponse> DeleteAsync(string url, string token = null)
        { return SendRequestAsync(Method.DELETE, url, string.Empty, token); }

        public static Task<IRestResponse> PostMultipartAsync(string url, string token,
            Func<RestRequest, Task> func)
        {
            return SendRequestAsync(Method.POST, url, token, func);
        }

        public static Task<IRestResponse> PutAsync(string url, object dto, string token = null)
        { return SendRequestAsync(Method.PUT, url, JsonConvert.SerializeObject(dto), token); }

        #endregion

        private static T SendRequest<T>(Method method, string url, string body, string token)
        {
            ServicePointManager.SecurityProtocol =
                SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            using var client = new BaseClient(url);

            try
            {
                var request = InitializeJsonRequest(method, body, token);

                return JsonConvert.DeserializeObject<T>(client.Execute(request).Content);
            }
            catch
            {
                return default;
            }
        }

        private static async Task<IRestResponse> SendRequestAsync(Method method,
            string url, string body, string token)
        {
            ServicePointManager.SecurityProtocol =
                SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            IRestResponse response = new RestResponse();

            using var client = new BaseClient(url);

            try
            {
                var request = InitializeJsonRequest(method, body, token);
                request.AddHeader("Accept-Language", LocalizationsManager.GetLanguageCulture());
                //request.AddOrUpdateHeader("user", GetLoggedInUSer());

                response = await client.ExecuteAsync(request);
            }
            catch (WebException webException)
            {
                Log.Error(webException, "External Api Request Url Helper");

                var errResp = webException.Response;

                await using var respStream = errResp?.GetResponseStream();

                if (respStream is null) return response;

                var reader = new StreamReader(respStream);
                var text = await reader.ReadToEndAsync();

                response.StatusCode = HttpStatusCode.ExpectationFailed;
                response.Content = text;
            }
            catch (Exception exception)
            {
                Log.Error(exception, "External Api Request Url Helper");

                response.StatusCode = HttpStatusCode.ExpectationFailed;
                response.Content = exception.Message;
            }

            return response;
        }

        private static async Task<IRestResponse> SendRequestAsync(
            Method method,
            string url,
            string token,
            Func<RestRequest, Task> func)
        {
            ServicePointManager.SecurityProtocol =
                SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            IRestResponse response = new RestResponse();

            using var client = new BaseClient(url);

            try
            {
                var request = await InitializeMultipartRequest(method, token, func);
                request.AddHeader("Accept-Language", LocalizationsManager.GetLanguageCulture());
                request.AddOrUpdateHeader("user", GetLoggedInUSer());

                response = await client.ExecuteAsync(request);
            }
            catch (WebException webException)
            {
                Log.Error(webException, "External Api Request Url Helper");

                var errResp = webException.Response;

                await using var respStream = errResp?.GetResponseStream();

                if (respStream is null) return response;

                var reader = new StreamReader(respStream);
                var text = await reader.ReadToEndAsync();

                response.StatusCode = HttpStatusCode.ExpectationFailed;
                response.Content = text;
            }
            catch (Exception exception)
            {
                Log.Error(exception, "External Api Request Url Helper");

                response.StatusCode = HttpStatusCode.ExpectationFailed;
                response.Content = exception.Message;
            }

            return response;
        }

        private static async Task<IRestResponse> SendFormRequestAsync(
        Method method,
        string url,
        string token,
        Func<RestRequest, Task> func)
        {
            ServicePointManager.SecurityProtocol =
                SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            IRestResponse response = new RestResponse();

            using var client = new BaseClient(url);

            try
            {
                var request = await InitializeMultipartRequest(method, token, func);
                request.AddHeader("Accept-Language", LocalizationsManager.GetLanguageCulture());
                request.AddOrUpdateHeader("user", GetLoggedInUSer());
                response = await client.ExecuteAsync(request);
            }
            catch (WebException webException)
            {
                Log.Error(webException, "External Api Request Url Helper");

                var errResp = webException.Response;

                await using var respStream = errResp?.GetResponseStream();

                if (respStream is null) return response;

                var reader = new StreamReader(respStream);
                var text = await reader.ReadToEndAsync();

                response.StatusCode = HttpStatusCode.ExpectationFailed;
                response.Content = text;
            }
            catch (Exception exception)
            {
                Log.Error(exception, "External Api Request Url Helper");

                response.StatusCode = HttpStatusCode.ExpectationFailed;
                response.Content = exception.Message;
            }

            return response;
        }


        private static RestRequest InitializeJsonRequest(Method httpMethod, string objectToRequest,
            string token)
        {
            var request = InitializeRequest(httpMethod, token);
            if (!string.IsNullOrEmpty(objectToRequest))
            {
                request.AddParameter("application/json", objectToRequest, ParameterType.RequestBody);
            }
            return request;
        }

        private static async Task<RestRequest> InitializeMultipartRequest(
            Method httpMethod,
            string token,
            Func<RestRequest, Task> func)
        {
            var request = InitializeRequest(httpMethod, token);

            request.AlwaysMultipartFormData = true;

            await func(request);

            return request;
        }

        private static RestRequest InitializeRequest(Method httpMethod, string token)
        {
            var culture = Thread.CurrentThread.CurrentUICulture;
            var request = new RestRequest(httpMethod);

            request.AddHeader("Accept-Language", culture.Name);
            //request.AddOrUpdateHeader("user", GetLoggedInUSer());

            if (token != null) request.AddHeader("Authorization", "Bearer " + token);

            return request;
        }

        private static string GetLoggedInUSer()
        {
            var provider = _serviceProvider.BuildServiceProvider();
            var dependency = provider.GetRequiredService<IHttpContextAccessor>();
            return dependency.HttpContext.User.Identity.Name;
        }
    }
}
