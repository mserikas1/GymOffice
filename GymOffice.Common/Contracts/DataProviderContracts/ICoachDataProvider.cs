namespace GymOffice.Common.Contracts.DataProviderContracts;
public interface ICoachDataProvider
{
    Task<Coach?> GetCoachByIdAsync(Guid id);
    Task<ICollection<Coach>?> GetAllCoachesAsync();
    Task<ICollection<Coach>?> GetCoachesAtWorkAsync();
    Task<ICollection<Coach>?> GetActiveCoachesAsync();
    Task<ICollection<Coach>?> GetActiveCoachesNotAtWorkAsync();
    Task<ICollection<Coach>?> GetCoachesNotAtWorkAsync();
}
