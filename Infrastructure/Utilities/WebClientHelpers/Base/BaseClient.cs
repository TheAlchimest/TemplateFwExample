using RestSharp;
using System;

namespace Dashboard.Common.WebClientHelpers.Base
{
    public class BaseClient : RestClient, IDisposable
    {
        public BaseClient()
        {

        }
        public BaseClient(string url)
        {
            BaseUrl = new Uri(url);
            Timeout = System.Threading.Timeout.Infinite;
        }
        public BaseClient(string host, string url)
        {
            BaseUrl = new Uri($"{host}{url}");
            Timeout = System.Threading.Timeout.Infinite;
        }

        // Flag: Has Dispose already been called?
        private bool disposed = false;

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {

            Dispose(true);
            GC.SuppressFinalize(this);
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                // Free any other managed objects here.
                //
            }

            // Free any unmanaged objects here.
            //
            disposed = true;
        }

        ~BaseClient()
        {
            Dispose(false);
        }
    }

}
