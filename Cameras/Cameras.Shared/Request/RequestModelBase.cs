using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace Cameras.Models.Request
{
    public abstract class RequestModelBase
    {
        public string UriPath { get; }

        public abstract Uri ToUri(Uri baseUri);

        public RequestModelBase(string uriPath)
        {
            UriPath = uriPath;
        }

        protected Uri BuildUri(Uri baseUri, Dictionary<string, string> queryParams)
        {
            var uriBuilder = new UriBuilder(baseUri);
            uriBuilder.Path = uriBuilder.Path.TrimEnd('/') + UriPath;
            if (queryParams != null && queryParams.Count > 0)
            {
                var parameters = HttpUtility.ParseQueryString(string.Empty);
                foreach (var item in queryParams)
                {
                    parameters[item.Key] = item.Value;
                }
                uriBuilder.Query = parameters.ToString();
            }
            return uriBuilder.Uri;
        }
    }
}
