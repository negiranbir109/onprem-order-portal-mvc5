using System;

namespace LegacyOrderPortal.DAL
{
    public class UnitOfWork : IDisposable
    {
        private readonly LegacyOrderContext context = new LegacyOrderContext();
        private OrderRepository orderRepository;

        public LegacyOrderContext Context => context;

        public OrderRepository OrderRepository
        {
            get
            {
                if (orderRepository == null)
                {
                    orderRepository = new OrderRepository(context);
                }

                return orderRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
