using ISI_Restaurant.Shared;
using ISI_Restaurant.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ISI_Restaurant.PaymentClient
{
    public interface IPayUClient
    {
        Task Pay(Order order); 
    }
}
