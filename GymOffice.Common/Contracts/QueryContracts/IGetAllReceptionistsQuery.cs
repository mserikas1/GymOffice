namespace GymOffice.Common.Contracts.QueryContracts;
public interface IGetAllReceptionistsQuery
{
    Task<IEnumerable<Receptionist>?> Exequte();
}
