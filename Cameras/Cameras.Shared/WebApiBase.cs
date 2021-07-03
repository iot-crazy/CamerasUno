﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Cameras
{
    public abstract class WebApiBase
    {
        // Insert variables below here
        protected static HttpClient _client;

        // Insert static constructor below here
        static WebApiBase()
        {
#if __WASM__
            var innerHandler = new Uno.UI.Wasm.WasmHttpHandler();
#else
            var innerHandler = new HttpClientHandler();
#endif
            _client = new HttpClient(innerHandler);
        }

        // Insert CreateRequestMessage method below here
        private HttpRequestMessage CreateRequestMessage(HttpMethod method, string url, Dictionary<string, string> headers = null)
        {
            var httpRequestMessage = new HttpRequestMessage(method, url);
            if (headers != null && headers.Any())
            {
                foreach (var header in headers)
                {
                    httpRequestMessage.Headers.Add(header.Key, header.Value);
                }
            }

            return httpRequestMessage;
        }

        // Insert GetAsync method below here
        protected async Task<string> GetAsync(string url, Dictionary<string, string> headers = null)
        {
            using (var request = CreateRequestMessage(HttpMethod.Get, url, headers))
            using (var response = await _client.SendAsync(request))
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }

                return null;
            }
        }

        // Insert DeleteAsync method below here

        // Insert PostAsync method below here

        // Insert PutAsync method below here
    }
}
