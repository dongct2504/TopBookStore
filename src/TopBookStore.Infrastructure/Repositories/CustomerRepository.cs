using TopBookStore.Domain.Entities;
using TopBookStore.Domain.Interfaces;
using TopBookStore.Infrastructure.Persistence;

namespace TopBookStore.Infrastructure.Repositories;

public class CustomerRepository : Repository<Customer>, ICustomerRepository
{
    public CustomerRepository(TopBookStoreContext context) : base(context)
    {
    }

    public void Update(Customer customer)
    {
        _context.Update(customer);
    }
}