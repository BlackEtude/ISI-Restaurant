using ISI_Restaurant.Shared.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ISI_Restaurant.PaymentClient
{
    public class PayUClient : IPayUClient
    {
        private readonly HttpClient httpClient;

        public PayUClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public Task Pay(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
