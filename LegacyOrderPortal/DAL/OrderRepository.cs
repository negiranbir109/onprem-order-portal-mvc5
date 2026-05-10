using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using LegacyOrderPortal.Models;

namespace LegacyOrderPortal.DAL
{
    public class OrderRepository
    {
        private readonly LegacyOrderContext context;

        public OrderRepository(LegacyOrderContext context)
        {
            this.context = context;
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return context.Orders.Include(o => o.Customer).Include(o => o.OrderItems.Select(i => i.Product)).ToList();
        }

        public Order GetOrderById(int id)
        {
            return context.Orders.Include(o => o.Customer).Include(o => o.OrderItems.Select(i => i.Product)).FirstOrDefault(o => o.OrderId == id);
        }

        public void AddOrder(Order order)
        {
            context.Orders.Add(order);
        }

        public void UpdateOrder(Order order)
        {
            context.Entry(order).State = EntityState.Modified;
        }
    }
}
