using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Reflection;

namespace ISI_Restaurant.RestApiClient
{
    public class ApiClientConfiguration
    {
        public ApiClientConfiguration(ILogger<ApiClientConfiguration> logger, IConfiguration configuration)
        {
            configuration.GetSection("Api").Bind(this);
            var missingConfiguration = GetType()
                .GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance)
                .Where(prop => prop.GetValue(this) == null)
                .ToList();
            missingConfiguration.ForEach(prop =>
            {
                logger.LogError($"API Client configuration missing: {prop.Name}");
            });
            if (missingConfiguration.Any())
            {
                throw new Exception("API Client configuration missing.");
            }
            else
            {
                logger.LogInformation("API Client configuration complete.");
            }
        }

        public string Scheme { get; set; }
        public string Host { get; set; }
        public int? Port { get; set; }
    }
}
