using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Domain.Model;
using Infrastructure.Database.Interfaces;
using Infrastructure.EntityFramework;

namespace Infrastructure.Database.EFImplementations
{
    public class CustomersRepository : IRepository<Customer>
    {
        private readonly SweetShopDataContext _context;

        public CustomersRepository(SweetShopDataContext context)
        {
            _context = context;
        }

        public Customer Get(int id)
        {
            return _context.Customers.Find(id);
        }

        public IList<Customer> GetAll()
        {
            return _context.Customers.ToList();
        }

        public Customer Create(Customer entity)
        {
            var сustomer = _context.Customers.Add(entity);
            return сustomer;
        }

        public Customer Edit(Customer entity)
        {
            var сustomer = _context.Customers.Find(entity.Id);
            if (сustomer != null)
            {
                сustomer.Name  = entity.Name;
                сustomer.Email = entity.Email;
                сustomer.Phone = entity.Phone;
            }
            return сustomer;
        }

        public bool Delete(Customer entity)
        {
            var сustomer = _context.Customers.Find(entity.Id);
            if (сustomer != null)
            {
                _context.Customers.Remove(сustomer);
                return true;
            }
            return false;
        }
    }
}
