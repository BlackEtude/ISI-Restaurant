using ISI_Restaurant.RestApiClient;
using ISI_Restaurant.Shared.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ISI_Restaurant.BlazorApp.Data
{
    public class FetchDataService
    {
        private readonly ILogger<FetchDataService> logger;
        private readonly IApiClient apiClient;

        public FetchDataService(ILogger<FetchDataService> logger, IApiClient apiClient)
        {
            this.logger = logger;
            this.apiClient = apiClient;
        }

        public async Task<IEnumerable<Product>> LoadMenu()
        {
            var menu = (await apiClient.GetProducts()).Result;
            logger.LogDebug("Menu items loaded.");
            return menu;
        }

        public async Task<IEnumerable<Topping>> GetToppings()
        {
            var toppings = (await apiClient.GetToppings()).Result;
            logger.LogDebug("Toppings loaded.");
            return toppings;
        }
    }
}
