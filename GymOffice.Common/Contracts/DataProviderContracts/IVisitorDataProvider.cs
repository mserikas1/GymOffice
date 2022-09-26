namespace GymOffice.Common.Contracts.DataProviderContracts;
public interface IVisitorDataProvider
{
    Task<ICollection<Visitor>?> GetVisitorsInGymAsync();
    Task<ICollection<Visitor>?> GetVisitorsNotInGymAsync();
    Task<ICollection<Visitor>?> GetActiveVisitorsNotInGymAsync();
    Task<ICollection<Visitor>?> GetAllVisitorsAsync();
    Task<ICollection<Visitor>?> GetActiveVisitorsAsync();
    Task<Visitor?> GetVisitorByIdAsync(Guid id);

}
