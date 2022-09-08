namespace GymOffice.Business.Queries;
public class GetCustomerByIdQuery : IGetCustomerByIdQuery
{
    private readonly ICustomerRepository _customerRepository;

    public GetCustomerByIdQuery(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<Customer?> Execute(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentNullException(nameof(id), "Incorrect coach Id");
        }

        Customer? customer = await _customerRepository.GetCustomerByIdAsync(id);

        if (customer == null)
        {
            throw new NotFoundException(nameof(Customer), id);
        }

        return customer;
    }
}
