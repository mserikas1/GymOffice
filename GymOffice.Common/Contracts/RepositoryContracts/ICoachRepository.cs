namespace GymOffice.Common.Contracts.RepositoryContracts;
public interface ICoachRepository
{
    Task<ICollection<Coach>?> GetAllCoachesAsync();
}
