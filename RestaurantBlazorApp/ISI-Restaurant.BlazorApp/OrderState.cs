using ISI_Restaurant.Shared.Models;

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
