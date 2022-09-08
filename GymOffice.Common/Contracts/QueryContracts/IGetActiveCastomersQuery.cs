namespace GymOffice.Common.Contracts.QueryContracts;
public interface IGetActiveCastomersQuery
{
    Task<IEnumerable<Customer>?> Execute();
}
