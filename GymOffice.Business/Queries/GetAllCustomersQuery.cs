namespace GymOffice.Business.Queries;
public class GetAllCustomersQuery : IGetAllCustomersQuery
{
    private readonly ICustomerRepository _customerRepository;

    public GetAllCustomersQuery(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<IEnumerable<Customer>?> Execute()
    {
        return await _customerRepository.GetCustomersAsync();
    }
}
