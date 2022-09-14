namespace GymOffice.Common.Contracts.RepositoryContracts;
public interface IVisitorRepository
{
    Task<IEnumerable<Visitor>?> GetVisitorsAsync();
    Task<IEnumerable<Visitor>?> GetActiveVisitorsAsync();
    Task<Visitor?> GetVisitorByIdAsync(Guid id);
    Task<Guid> AddVisitorAsync(Visitor Visitor);
    Task<Visitor> UpdateVisitorAsync(Visitor Visitor);
    Task<Visitor> DeleteVisitorAsync(Guid id);
}
