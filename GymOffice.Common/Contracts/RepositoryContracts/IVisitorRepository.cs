namespace GymOffice.Common.Contracts.RepositoryContracts;
public interface IVisitorRepository
{
    Task<ICollection<Visitor>?> GetVisitorsAsync();
    Task<ICollection<Visitor>?> GetActiveVisitorsAsync();
    Task<ICollection<Visitor>?> GetInactiveVisitorsAsync();
    Task<Visitor?> GetVisitorByIdAsync(Guid id);
    Task AddVisitorAsync(Visitor visitor);
    Task UpdateVisitorAsync(Visitor visitor);
    Task<VisitorCard?> GetVisitorCardByIdAsync(Guid id);
    Task AddVisitorCardAsync(VisitorCard visitorCard);
}
