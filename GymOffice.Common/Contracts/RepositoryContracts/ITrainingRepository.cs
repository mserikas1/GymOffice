namespace GymOffice.Common.Contracts.RepositoryContracts;
public interface ITrainingRepository
{
    Task<IEnumerable<Training>?> GetAllTrainingAsync();
    Task<IEnumerable<Training>?> GetTrainingByCustomerAsync(Guid id);
    Task<IEnumerable<Training>?> GetTrainingByCoachAsync(Guid id);
    Task<Guid> AddTrainingAsync(Training training);
    Task<Training?> DeleteTrainingAsync(Guid id);
    Task<Training?> UpdateTrainingAsync(Training training);
}
