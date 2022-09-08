namespace GymOffice.Common.Contracts.QueryContracts;
public interface IGetActiveCoachesQuery
{
    Task<IEnumerable<Coach>?> Execute();
}
