﻿using ISI_Restaurant.RestApiClient;
using ISI_Restaurant.Shared.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ISI_Restaurant.BlazorApp.Data
{
    public class FetchMenuService
    {
        private readonly ILogger<FetchMenuService> logger;
        private readonly IApiClient apiClient;

        public FetchMenuService(ILogger<FetchMenuService> logger, IApiClient apiClient)
        {
            this.logger = logger;
            this.apiClient = apiClient;
        }

        public async Task<IEnumerable<MenuItem>> LoadDummyMenu()
        {
            var toppings = new List<Topping>()
            {
                new Topping() { Id = 1, Name = "szynka", Price = 3.0 },
                new Topping() { Id = 2, Name = "boczek", Price = 3.0 },
                new Topping() { Id = 3, Name = "owoce morza", Price = 4.0 },
                new Topping() { Id = 4, Name = "tuńczyk", Price = 3.0 },
                new Topping() { Id = 5, Name = "ananas", Price = 2.0 },
                new Topping() { Id = 6, Name = "cebula", Price = 2.0 },
                new Topping() { Id = 7, Name = "kukurydza", Price = 2.0 },
                new Topping() { Id = 8, Name = "papryka", Price = 2.0 },
            };

            var products = new List<Product>()
            {
                new Product() { Id = 1, Name = "Pizza Minimal", Description = "sos pomidorowy, bazylia, ser", Price = 19 },
                new Product() { Id = 2, Name = "Pizza Chillout", Description = "sos pomidorowy, pieczarki, ser", Price = 21 },
                new Product() { Id = 3, Name = "Pizza Pop", Description = "sos pomidorowy, szynka, ser", Price = 22 },
                new Product() { Id = 4, Name = "Pizza Salsa", Description = "sos pomidorowy, pieczarki, salami, ser", Price = 23 },
                new Product() { Id = 5, Name = "Pissa Classic", Description = "sos pomidorowy, pieczarki, ser, szynka", Price = 23 }
            };

            var menuItems = new List<MenuItem>()
            {
                new MenuItem() { Product = products[0], Toppings = toppings.GetRange(0, 4), ImagePath = "img/pizzas/margherita.jpg" },
                new MenuItem() { Product = products[1], Toppings = toppings.GetRange(2, 6), ImagePath = "img/pizzas/pepperoni.jpg" },
                new MenuItem() { Product = products[2], Toppings = toppings.GetRange(0, 3), ImagePath = "img/pizzas/meaty.jpg" },
                new MenuItem() { Product = products[3], Toppings = toppings.GetRange(3, 3), ImagePath = "img/pizzas/mushroom.jpg" },
                new MenuItem() { Product = products[4], Toppings = toppings.GetRange(0, 1), ImagePath = "img/pizzas/bacon.jpg" }
            };

            var menu = await Task.FromResult<IEnumerable<MenuItem>>(menuItems);
            logger.LogDebug("Menu items loaded.");

            return menu;
        }
    }
}
