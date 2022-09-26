namespace GymOffice.Common.Contracts.DataProviderContracts;
public interface ICoachDataProvider
{
    Task<ICollection<Coach>?> GetAllCoachesAsync();
}
