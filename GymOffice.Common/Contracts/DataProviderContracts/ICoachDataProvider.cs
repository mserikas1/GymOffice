namespace GymOffice.Common.Contracts.DataProviderContracts;
public interface ICoachDataProvider
{
    Task<Coach?> GetCoachByIdAsync(Guid id);
    Task<IEnumerable<Coach>?> GetAllCoachesAsync();
    Task<IEnumerable<Coach>?> GetActiveCoachesAsync();
    Task<IEnumerable<Coach>?> SearchCoachesAsync(CoachSearchOptions searchParams);
}
