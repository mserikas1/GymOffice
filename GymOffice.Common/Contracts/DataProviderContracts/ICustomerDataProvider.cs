namespace GymOffice.Common.Contracts.DataProviderContracts;
public interface ICustomerDataProvider
{
    Task<IEnumerable<Customer>?> GetActiveCustomersAsync();
    Task<IEnumerable<Customer>?> GetAllCustomersAsync();
    Task<Customer?> GetCustomerByEmailAsync(string email);
    Task<Customer?> GetCustomerByIdAsync(Guid id);
    Task<Customer?> GetCustomerByPhoneAsync(string phoneNumber);
    Task<IEnumerable<Customer>?> GetCustomersByFirstNameAsync(string firstName);
    Task<IEnumerable<Customer>?> GetCustomersByLastNameAsync(string lastName);
    Task<IEnumerable<Customer>?> GetCustomersByRegistrationDateAsync(DateTime? startDate, DateTime? endDate);
    Task<IEnumerable<Customer>?> SerchCustomersAsync(CustomerSearchOptions options);
}
