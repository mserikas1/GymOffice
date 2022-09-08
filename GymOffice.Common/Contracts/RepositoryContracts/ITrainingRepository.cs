namespace GymOffice.Common.Contracts.RepositoryContracts;
public interface ITrainingRepository
{
    Task<IEnumerable<PersonalTraining>?> GetAllTrainingAsync();
    Task<IEnumerable<PersonalTraining>?> GetTrainingByCustomerAsync(Guid id);
    Task<IEnumerable<PersonalTraining>?> GetTrainingByCoachAsync(Guid id);
    Task<Guid> AddTrainingAsync(PersonalTraining training);
    Task<PersonalTraining?> DeleteTrainingAsync(Guid id);
    Task<PersonalTraining?> UpdateTrainingAsync(PersonalTraining training);
}
