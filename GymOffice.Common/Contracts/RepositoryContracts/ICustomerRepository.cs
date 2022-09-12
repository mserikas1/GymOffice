namespace GymOffice.Common.Contracts.RepositoryContracts;
public interface ICustomerRepository
{
    Task<IEnumerable<Customer>?> GetCustomersAsync();
    Task<IEnumerable<Customer>?> GetActiveCustomersAsync();
    Task<Customer?> GetByIdAsync(Guid id);
    Task<Guid> AddCustomerAsync(Customer customer);
    Task<Customer> UpdateCustomerAsync(Customer customer);
    Task<Customer> DeleteCustomerAsync(Guid id);
    Task<Customer> GetByEmailAsync(string email);
    Task<Customer?> GetByPhoneAsync(string phoneNumber);
    Task<IEnumerable<Customer>?> GetCustomersByFirstNameAsync(string firstName);
    Task<IEnumerable<Customer>?> GetCustomersByLastNameAsync(string lastName);
    Task<IEnumerable<Customer>?> GetCustomersByRegistrationDateAsync(DateTime? startDate, DateTime? endDate);
    Task<IEnumerable<Customer>?> SearchCustomersAsync(CustomerSearchOptions options);
    Task AddAbonnementToCustomerAsync(Abonnement abonnement, Guid customerId);
    Task DeleteGroupTrainingFromCustomerAsync(Guid trainingId, Guid customerId);
}
