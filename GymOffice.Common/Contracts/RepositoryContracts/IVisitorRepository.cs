namespace GymOffice.Common.Contracts.RepositoryContracts;
public interface IVisitorRepository
{
<<<<<<< HEAD
    Task<ICollection<Visitor>?> GetVisitorsAsync();
=======
    Task<ICollection<Visitor>?> GetAllVisitorsAsync();
    Task<ICollection<Visitor>?> GetActiveVisitorsAsync();
    Task<ICollection<Visitor>?> GetVisitorsInGymAsync();
    Task<ICollection<Visitor>?> GetVisitorsNotInGymAsync();
    Task<ICollection<Visitor>?> GetActiveVisitorsNotInGymAsync();
    Task<Visitor?> GetVisitorByIdAsync(Guid id);
    Task AddVisitorAsync(Visitor visitor);
    Task UpdateVisitorAsync(Visitor visitor);
    Task<VisitorCard?> GetVisitorCardByIdAsync(Guid id);
    Task AddVisitorCardAsync(VisitorCard visitorCard);
>>>>>>> oleg-feature-receptionist-pages
}
