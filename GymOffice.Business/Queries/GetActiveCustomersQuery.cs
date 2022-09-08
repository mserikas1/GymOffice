namespace GymOffice.Business.Queries;
public class GetActiveCustomersQuery : IGetActiveCastomersQuery
{
    private readonly ICustomerRepository _customerRepository;

    public GetActiveCustomersQuery(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<IEnumerable<Customer>?> Execute()
    {
        return await _customerRepository.GetActiveCustomersAsync();
    }
}
