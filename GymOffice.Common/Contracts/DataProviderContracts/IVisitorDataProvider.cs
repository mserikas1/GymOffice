namespace GymOffice.Common.Contracts.DataProviderContracts;
public interface IVisitorDataProvider
{
    Task<ICollection<Visitor>?> GetAllVisitorsAsync();
}
