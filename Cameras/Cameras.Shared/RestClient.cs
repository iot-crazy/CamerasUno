using Cameras.Models.Request;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Cameras
{
    public class RestClient : WebApiBase
    {
        private readonly Uri _baseUri;

        public RestClient(Uri baseUri)
        {
            _baseUri = baseUri;
        }

        public async Task<T> Request<T>(RequestModelBase requestModel)
        {
            var uri = requestModel.ToUri(_baseUri).ToString();

            var result = await GetAsync(
               uri,
                new Dictionary<string, string> {
                    {"accept", "application/json" },
                });

            if (result != null)
            {
                return JsonSerializer.Deserialize<T>(result, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }

            return default;
        }
    }
}
