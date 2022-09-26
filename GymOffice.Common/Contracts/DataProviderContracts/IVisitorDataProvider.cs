namespace GymOffice.Common.Contracts.DataProviderContracts;
public interface IVisitorDataProvider
{
    Task<ICollection<Visitor>?> GetVisitorsInGymAsync();
    Task<ICollection<Visitor>?> GetVisitorsNotInGymAsync();
    Task<ICollection<Visitor>?> GetAllVisitorsAsync();
    Task<Visitor?> GetVisitorByIdAsync(Guid id);

}
