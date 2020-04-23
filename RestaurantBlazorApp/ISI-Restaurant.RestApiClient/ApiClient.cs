using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;

namespace ISI_Restaurant.RestApiClient
{
    public class ApiClient : IApiClient
    {
        private readonly HttpClient httpClient;
        private readonly ILogger logger;
        private readonly Uri baseUri;

        public ApiClient(HttpClient httpClient, ILogger<ApiClient> logger)
        {
            this.httpClient = httpClient;
            this.logger = logger;
            var uriBuilder = new UriBuilder
            {
                Scheme = "http",
                Host = "localhost",
                Port = 8983
            };
            baseUri = uriBuilder.Uri;
        }

    }
}
