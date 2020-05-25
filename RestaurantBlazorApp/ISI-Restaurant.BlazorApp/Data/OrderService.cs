using ISI_Restaurant.RestApiClient;
using ISI_Restaurant.Shared.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ISI_Restaurant.BlazorApp.Data
{
    public class OrderService
    {
        private readonly ILogger<OrderService> logger;
        private readonly IApiClient apiClient;

        public int? LastPlacedOrder { get; private set; } = null;

        public OrderService(ILogger<OrderService> logger, IApiClient apiClient)
        {
            this.logger = logger;
            this.apiClient = apiClient;
        }

        public async Task<Order> LoadOrder()
        {
            if (LastPlacedOrder is null)
            {
                return null;
            }

            var order = (await apiClient.GetOrder(LastPlacedOrder.Value)).Result;
            logger.LogDebug("Order loaded.");
            return order;
        }

        public async Task PlaceNewOrder(Order order)
        {
            LastPlacedOrder = await apiClient.SendNewOrder(order);
        }

        public async Task<IEnumerable<DeliveryPoint>> GetDeliveryPoints()
        {
            var deliveryPoints = (await apiClient.GetDeliveryPoints()).Result;
            logger.LogDebug("Deliver points loaded.");
            return deliveryPoints;
        }
    }
}
