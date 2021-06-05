using S10_NETCOREWeb.Domain.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace S10_NETCOREWeb.Domain.Core.Interfaces
{
    public interface ICustomerRepository
    {
        Task<bool> DeleteCustomer(int id);
        Task<Customer> GetCustomerById(int id);
        Task<IEnumerable<Customer>> GetCustomers();
        Task InsertCustomer(Customer customer);
        Task<bool> UpdateCustomer(Customer customer);
    }
}