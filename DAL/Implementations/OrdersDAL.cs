using DAL.Interfaces;
using Entities.Entities;

namespace DAL.Implementations
{
    public class OrdersDAL : DALGenericoImpl<Order>, IOrdersDAL
    {
        private readonly NorthwndContext _context;

        public OrdersDAL(NorthwndContext context) : base(context)
        {
            _context = context;
        }
    }
}
