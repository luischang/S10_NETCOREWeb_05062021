using Microsoft.EntityFrameworkCore;
using S10_NETCOREWeb.Domain.Core.Entities;
using S10_NETCOREWeb.Domain.Core.Interfaces;
using S10_NETCOREWeb.Domain.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S10_NETCOREWeb.Domain.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly SalesContext _context;

        public CustomerRepository(SalesContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            //using var data = new SalesContext();
            //return await data.Customer.ToListAsync();

            return await _context.Customer.ToListAsync();
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            return await _context.Customer.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task InsertCustomer(Customer customer)
        {
            _context.Customer.Add(customer);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateCustomer(Customer customer)
        {
            var customerNow = await _context.Customer
                                    .Where(x => x.Id == customer.Id).FirstOrDefaultAsync();

            customerNow.FirstName = customer.FirstName;
            customerNow.LastName = customer.LastName;
            customerNow.Country = customer.Country;
            customerNow.City = customer.City;
            customerNow.Phone = customer.Phone;

            int countRows = await _context.SaveChangesAsync();

            return (countRows > 0);
        }

        public async Task<bool> DeleteCustomer(int id)
        {
            var customerNow = await _context.Customer
                                   .Where(x => x.Id == id).FirstOrDefaultAsync();
            if (customerNow == null)
                return false;
            _context.Customer.Remove(customerNow);
            int countRows = await _context.SaveChangesAsync();
            return (countRows > 0);
        }



    }
}
