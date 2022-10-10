namespace GymOffice.Common.Contracts.RepositoryContracts;
public interface IAdvantageRepository
{
    Task AddAdvantageAsync(Advantage advantage);
    Task<ICollection<Advantage>?> GetAdvantagesAsync();
    Task<Advantage?> GetAdvantageByIdAsync(Guid id);
    Task UpdateAdvantageAsync(Advantage advantage);
    Task<ICollection<Advantage>?> SearchAdvantagesAsync(AdvantageSearchOptions options);
}
