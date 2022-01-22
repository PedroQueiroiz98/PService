using PS.Domain.Shared;

namespace PS.Domain.Customer;
public interface ICustomerRepository : IRepository<Customer>{
    
   Task<Customer> FindIdAsync(int id);
}