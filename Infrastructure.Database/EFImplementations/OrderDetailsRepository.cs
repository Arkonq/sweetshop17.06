using System.Collections.Generic;
using Domain.Model;
using Infrastructure.Database.Interfaces;
using Infrastructure.EntityFramework;

namespace Infrastructure.Database.EFImplementations
{
    public class OrderDetailsRepository : IRepository<OrderDetail>
    {
        private readonly SweetShopDataContext _context;

        public OrderDetailsRepository(SweetShopDataContext context)
        {
            _context = context;
        }

        public OrderDetail Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public IList<OrderDetail> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public OrderDetail Create(OrderDetail entity)
        {
            return _context.OrderDetails.Add(entity);
        }

        public OrderDetail Edit(OrderDetail entity)
        {
            throw new System.NotImplementedException();
        }

		public bool Delete(OrderDetail entity)
		{
			throw new System.NotImplementedException();
		}
	}
}