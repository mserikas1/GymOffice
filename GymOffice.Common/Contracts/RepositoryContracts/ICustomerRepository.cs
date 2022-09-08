namespace GymOffice.Common.Contracts.RepositoryContracts;
public interface ICustomerRepository
{
    Task<IEnumerable<Customer>?> GetCustomersAsync();
    Task<IEnumerable<Customer>?> GetActiveCustomersAsync();
    Task<Customer?> GetCustomerByIdAsync(Guid id);
    Task<Guid> AddCustomerAsync(Customer customer);
    Task<Customer> UpdateCustomerAsync(Customer customer);
    Task<Customer> DeleteCustomerAsync(Guid id);
}
