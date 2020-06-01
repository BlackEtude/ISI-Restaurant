﻿using ISI_Restaurant.RestApiClient;
using ISI_Restaurant.Shared.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.IO;

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
            // amend with client IP Address
            order.CustomerData.IpAddress = GetPublicIP();

            var orderResponse = await apiClient.SendNewOrder(order);
            LastPlacedOrder = (int)orderResponse.Order.Id;
        }

        public async Task<IEnumerable<DeliveryPoint>> GetDeliveryPoints()
        {
            var deliveryPoints = (await apiClient.GetDeliveryPoints()).Result;
            logger.LogDebug("Deliver points loaded.");
            return deliveryPoints;
        }

        private string GetPublicIP()
        {
            string myPublicIp = "";
            WebRequest request = WebRequest.Create("https://api.ipify.org/");
            using (WebResponse response = request.GetResponse())
            using (StreamReader stream = new StreamReader(response.GetResponseStream()))
            {
                myPublicIp = stream.ReadToEnd();
            }
            return myPublicIp;
        }
    }
}
