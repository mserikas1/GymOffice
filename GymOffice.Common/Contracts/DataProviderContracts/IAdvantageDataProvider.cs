namespace GymOffice.Common.Contracts.DataProviderContracts;
public interface IAdvantageDataProvider
{
    Task<Advantage?> GetAdvantageByIdAsync(Guid id);
    Task<ICollection<Advantage>?> GetAdvantagesAsync();
    Task<ICollection<Advantage>?> SearchAdvantagesAsync(AdvantageSearchOptions options);
}
