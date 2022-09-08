namespace GymOffice.Common.Contracts.QueryContracts;
public interface IGetAllAdministratorsQuery
{
    Task<IEnumerable<Administrator>?> Execute();
}
