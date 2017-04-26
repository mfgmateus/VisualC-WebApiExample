using System.Collections.Generic;
using System.Linq;

namespace PocApi.Models
{
    public class CustomerRepository : ICustomerRepository
    {

        private readonly CustomerContext _context;

        public CustomerRepository(CustomerContext context)
        {
            _context = context;

        }

        public void Add(Customer item)
        {
            _context.Customers.Add(item);
            _context.SaveChanges();

        }

        public Customer Find(int key)
        {
            return _context.Customers.FirstOrDefault(t => t.Key == key);
        }

        public IEnumerable<Customer> GetAll()
        {
            return _context.Customers.ToList();
        }

        public void Remove(int key)
        {
            var entity = _context.Customers.First(t => t.Key == key);
            _context.Customers.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(Customer item)
        {
            _context.Customers.Update(item);
            _context.SaveChanges();
        }
    }
}
