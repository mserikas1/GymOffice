namespace GymOffice.Common.Contracts.RepositoryContracts;
public interface IVisitorRepository
{
    Task<ICollection<Visitor>?> GetVisitorsAsync();
}
