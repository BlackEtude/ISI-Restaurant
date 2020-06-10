using ISI_Restaurant.RestApiClient.OAuth;
using ISI_Restaurant.Shared;
using ISI_Restaurant.Shared.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace ISI_Restaurant.RestApiClient
{
    public class ApiClient : IApiClient
    {
        private readonly HttpClient httpClient;
        private readonly ILogger logger;
        private readonly AuthorizationAuthority authAuthority;
        private readonly Uri baseUri;

        public ApiClient(HttpClient httpClient, ILogger<ApiClient> logger, ApiClientConfiguration configuration, AuthorizationAuthority authAuthority)
        {
            this.httpClient = httpClient;
            this.logger = logger;
            this.authAuthority = authAuthority;
            var uriBuilder = new UriBuilder
            {
                Scheme = configuration.Scheme,
                Host = configuration.Host,
                Port = configuration.Port.Value
            };
            baseUri = uriBuilder.Uri;
        }

        private async Task SetBearer()
        {
            var token = await authAuthority.GetAccessToken();
            httpClient.SetBearerToken(token);
        }

        public async Task<RequestResult<T>> Get<T>(string relativeUri)
        {
            await SetBearer();

            var uri = new Uri(baseUri, relativeUri);
            try
            {
                var httpResponse = await httpClient.GetAsync(uri);
                if (httpResponse.StatusCode != HttpStatusCode.OK)
                {
                    logger.LogError($"Request failed with status code {httpResponse.StatusCode} for uri: {relativeUri}.");
                    return new RequestResult<T>(Status.Error);
                }
                var responseStream = await httpResponse.Content.ReadAsStreamAsync();
                if (!TryDeserialize<T>(responseStream, out var requestResult))
                {
                    logger.LogError($"API returned invalid content format for uri: {relativeUri}.");
                    return new RequestResult<T>(Status.Error);
                }
                logger.LogInformation($"Response received for uri: {relativeUri}.");
                return new RequestResult<T>(Status.OK, requestResult);
            }
            catch (TaskCanceledException)
            {
                logger.LogError($"Request timed out for uri: {relativeUri}.");
                return new RequestResult<T>(Status.Waiting);
            }
            catch (HttpRequestException ex)
            {
                logger.LogWarning($"Request failed for uri: {relativeUri} with exception: {ex}.");
                return new RequestResult<T>(Status.Error);
            }
        }

        public async Task<RequestResult<IEnumerable<Product>>> GetProducts()
            => await Get<IEnumerable<Product>>(relativeUri: "product");

        public async Task<RequestResult<IEnumerable<Topping>>> GetToppings() 
            => await Get<IEnumerable<Topping>>(relativeUri: "topping");

        public async Task<RequestResult<Order>> GetOrder(int id)
            => await Get<Order>(relativeUri: Path.Combine("order", id.ToString()));

        public async Task<RequestResult<IEnumerable<DeliveryPoint>>> GetDeliveryPoints()
            => await Get<IEnumerable<DeliveryPoint>>(relativeUri: "deliverypoint");

        public async Task<CreatedOrderResponse> SendNewOrder(Order order)
        {
            var uri = new Uri(baseUri, "order");

            await SetBearer();

            var httpResponse = await httpClient.PostAsJsonAsync(uri, order);
            var responseStream = await httpResponse.Content.ReadAsStreamAsync();

            if (!TryDeserialize<CreatedOrderResponse>(responseStream, out var orderReceived))
            {
                logger.LogError($"API returned invalid content format.");
                return default;
            }
            return orderReceived;
        }

        public static bool TryDeserialize<T>(Stream stream, out T obj)
        {
            try
            {
                var serializer = new JsonSerializer();
                using (var sr = new StreamReader(stream))
                using (var jsonTextReader = new JsonTextReader(sr))
                {
                    obj = serializer.Deserialize<T>(jsonTextReader);
                }
                return true;
            }
            catch (Exception e)
            {
                System.Diagnostics.Trace.TraceWarning(e.Message);
                obj = default;
                return false;
            }
        }
    }
}
