namespace GymOffice.Common.Contracts.DataProviderContracts;
public interface IVisitorDataProvider
{
    Task<ICollection<Visitor>?> GetActiveVisitorsAsync();
    Task<ICollection<Visitor>?> GetInactiveVisitorsAsync();
    Task<ICollection<Visitor>?> GetAllVisitorsAsync();
    Task<Visitor?> GetVisitorByIdAsync(Guid id);

}
