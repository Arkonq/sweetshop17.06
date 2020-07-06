using System.Collections.Generic;
using System.Linq;
using Domain.Model;
using Infrastructure.Database.Interfaces;
using Infrastructure.EntityFramework;

namespace Infrastructure.Database.EFImplementations
{
    public class OrdersRepository : IRepository<Order>
    {
        private readonly SweetShopDataContext _context;

        public OrdersRepository(SweetShopDataContext context)
        {
            _context = context;
        }

        public Order Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public IList<Order> GetAll()
        {
            return _context.Orders.ToList();
        }

        public Order Create(Order entity)
        {
            return _context.Orders.Add(entity);
        }

        public Order Edit(Order entity)
        {
            throw new System.NotImplementedException();
        }

		public bool Delete(Order entity)
		{
			throw new System.NotImplementedException();
		}
	}
}