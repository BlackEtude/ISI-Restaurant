using ISI_Restaurant.Shared;
using ISI_Restaurant.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ISI_Restaurant.RestApiClient
{
    public interface IApiClient
    {
        Task<RequestResult<IEnumerable<Product>>> GetProducts();
        Task<RequestResult<IEnumerable<Topping>>> GetToppings();
        Task<RequestResult<Order>> GetOrder(int id);
        Task<RequestResult<IEnumerable<DeliveryPoint>>> GetDeliveryPoints();
        Task<int> SendNewOrder(Order order);
    }
}
