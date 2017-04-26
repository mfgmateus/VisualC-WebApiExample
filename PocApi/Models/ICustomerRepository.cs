using System.Collections.Generic;

namespace PocApi.Models
{
    public interface ICustomerRepository
    {
        void Add(Customer item);
        IEnumerable<Customer> GetAll();
        Customer Find(int key);
        void Remove(int key);
        void Update(Customer item);
    }
}