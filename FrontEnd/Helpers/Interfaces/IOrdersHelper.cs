using FrontEnd.Models;
using System.Collections.Generic;

namespace FrontEnd.Helpers.Interfaces
{
    public interface IOrdersHelper
    {
        List<OrderViewModel> GetAllOrders();
        OrderViewModel GetOrder(int id);
        OrderViewModel Add(OrderViewModel order);
        OrderViewModel Update(OrderViewModel order);
        void Delete(int id);
    }
}
