using IdentityModel.Client;
using System;
using System.Threading.Tasks;

namespace ISI_Restaurant.RestApiClient.OAuth
{
    public class AuthorizationAuthority
    {
        private DateTime tokenValidUntil;
        private readonly TokenClient tokenClient;

        public string AccessToken { get; private set; }

        public AuthorizationAuthority(ApiClientConfiguration configuration)
        {
            var uriBuilder = new UriBuilder
            {
                Scheme = configuration.Scheme,
                Host = configuration.Host,
                Port = configuration.Port.Value
            };
            var baseUri = uriBuilder.Uri;
            tokenClient = new TokenClient(new Uri(baseUri, configuration.AuthDomain).ToString(), configuration.ClientId, configuration.ClientSecret);
        }

        public async Task<string> GetAccessToken()
        {
            if (AccessToken is null || IsTokenExpired())
            {
                var tokenResponse = await RequestTokenAsync();
                if (!tokenResponse.IsError)
                {
                    tokenValidUntil = DateTime.Now.AddSeconds(tokenResponse.ExpiresIn);
                    AccessToken = tokenResponse.AccessToken;
                }
            }
            return AccessToken;
        }

        private bool IsTokenExpired()
            => DateTime.Now >= tokenValidUntil.Subtract(new TimeSpan(0, 5, 0));

        public async Task<TokenResponse> RequestTokenAsync()
            => await tokenClient.RequestClientCredentialsAsync("all");
    }
}
