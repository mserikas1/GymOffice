namespace GymOffice.Common.Contracts.QueryContracts;
public interface IGetCustomerByIdQuery
{
    Task<Customer?> Execute(Guid id);
}
