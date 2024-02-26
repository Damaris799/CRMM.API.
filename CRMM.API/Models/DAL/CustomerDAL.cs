using CRM.API.Models.EN;
using Microsoft.EntityFrameworkCore;

namespace CRM.API.Models.DAL
{
    public class CustomerDAL
    {
        readonly CRMContext _Context;

        public CustomerDAL(CRMContext cRMContext)
        {
            _Context = cRMContext;
        }

        public async Task<int> Create(Customer customer)
        {
            _Context.Add(customer);
            return await _Context.SaveChangesAsync();
        }

        public async Task<Customer> GetById(int id)
        {
            var customer = await _Context.Customers.FirstOrDefaultAsync(s => s.Id == id);
            return customer != null ? customer : new Customer();
        }
        public async Task<int> Edit(Customer customer)
        {
            int result = 0;
            var customerUpdate = await GetById(customer.Id);
            if (customerUpdate.Id != 0)
            {
                customer.Name = customer.Name;
                customer.LastName = customer.LastName;
                customerUpdate.Address = customer.Address;
                result = await _Context.SaveChangesAsync();
            }
            return result;
        }
        public async Task<int> Delete(int id)
        {
            int result = 0;
            var customerDelate = await GetById(id);
            if (customerDelate.Id > 0)
            {
                _Context.Customers.Remove(customerDelate);
                result = await _Context.SaveChangesAsync();
            }
            return result;
        }
        public async Task<int> edit(Customer customer)
        {
            int result = 0;
            var customerUpdate = await GetById(customer.Id);
            if (customerUpdate.Id != 0)
            {
                customerUpdate.Name = customer.Name;
                customerUpdate.LastName = customer.LastName;
                customerUpdate.Address = customer.Address;
                result = await _Context.SaveChangesAsync();
            }
            return result;
        }
        private IQueryable<Customer> Query(Customer customer)
        {
            var query = _Context.Customers.AsQueryable();
            if (!string.IsNullOrWhiteSpace(customer.Name))
                query = query.Where(s => s.LastName.Contains(customer.LastName));
            if (!string.IsNullOrWhiteSpace(customer.LastName))
                query = query.Where(s => s.LastName.Contains(customer.LastName));
            return query;
        }
        public async Task<List<Customer>> Search(Customer customer, int take = 10, int skip = 0)
        {
            take = take == 0 ? 10 : take;
            var query = Query(customer);
            query = query.OrderByDescending(s => s.Id).Skip(skip).Take(take);
            return await query.ToListAsync();
        }

        internal Task<int> CountSearch(Customer customer)
        {
            throw new NotImplementedException();
        }

        internal static Task<int> create(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
