using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;
using System.Collections.Generic;

namespace BackEnd.Services.Implementations
{
    public class OrdersService : IOrdersService
    {
        private readonly IOrdersDAL _ordersDAL;

        public OrdersService(IOrdersDAL ordersDAL)
        {
            _ordersDAL = ordersDAL;
        }

        public IEnumerable<Order> GetAll()
        {
            return _ordersDAL.GetAll();
        }

        public Order GetById(int id)
        {
            return _ordersDAL.Get(id);
        }

        public void Create(Order order)
        {
            _ordersDAL.Add(order);
        }

        public void Update(Order order)
        {
            _ordersDAL.Update(order);
        }

        public void Delete(int id)
        {
            var order = _ordersDAL.Get(id);
            if (order != null)
            {
                _ordersDAL.Delete(order);
            }
        }
    }
}
