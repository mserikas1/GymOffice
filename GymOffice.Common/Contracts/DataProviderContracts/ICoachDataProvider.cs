namespace GymOffice.Common.Contracts.DataProviderContracts;
public interface ICoachDataProvider
{
<<<<<<< HEAD
    Task<ICollection<Coach>?> GetAllCoachesAsync();
=======
    Task<Coach?> GetCoachByIdAsync(Guid id);
    Task<ICollection<Coach>?> GetAllCoachesAsync();
    Task<ICollection<Coach>?> GetCoachesAtWorkAsync();
    Task<ICollection<Coach>?> GetActiveCoachesAsync();
    Task<ICollection<Coach>?> GetActiveCoachesNotAtWorkAsync();
    Task<ICollection<Coach>?> GetCoachesNotAtWorkAsync();
>>>>>>> oleg-feature-receptionist-pages
}
