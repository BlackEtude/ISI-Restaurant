﻿using ISI_Restaurant.Shared.Models;
using System.Linq;

namespace ISI_Restaurant.BlazorApp
{
    public class OrderState
    {
        public bool ShowingConfigureDialog { get; private set; }

        public OrderItem Pizza { get; private set; }

        public Order Order { get; private set; } = new Order();

        public void ShowConfigurePizzaDialog(Product product)
        {
            Pizza = new OrderItem(product);
            ShowingConfigureDialog = true;
        }

        public void CancelConfigurePizzaDialog()
        {
            Pizza = null;
            ShowingConfigureDialog = false;
        }

        public void ConfirmConfigurePizzaDialog()
        {
            Order.Items.Add(Pizza);
            Pizza = null;

            ShowingConfigureDialog = false;
        }

        public void RemoveConfiguredPizza(OrderItem pizza)
        {
            Order.Items.Remove(pizza);
        }

        public void RemovedConfiguredPizzaTopping(OrderItem pizza, Topping topping)
        {
            var pizzaIndex = Order.Items.IndexOf(pizza);
            Order.Items.ElementAt(pizzaIndex).Toppings.RemoveAll(tp => tp == topping);
        }

        public void ResetOrder()
        {
            Order = new Order();
        }

        public void ReplaceOrder(Order order)
        {
            Order = order;
        }
    }
}
