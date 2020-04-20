using Microsoft.Extensions.Logging;
using System;

namespace ISI_Restaurant.HttpClient
{
    public class APIClient
    {
        private readonly HttpClient httpClient;
        private readonly ILogger logger;
        private readonly Uri baseUri;

        public APIClient(HttpClient httpClient, ILogger<APIClient> logger)
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
