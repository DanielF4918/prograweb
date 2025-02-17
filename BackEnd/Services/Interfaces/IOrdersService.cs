using Entities.Entities;
using System.Collections.Generic;

namespace BackEnd.Services.Interfaces
{
    public interface IOrdersService
    {
        IEnumerable<Order> GetAll();
        Order GetById(int id);
        void Create(Order order);
        void Update(Order order);
        void Delete(int id);
    }
}
