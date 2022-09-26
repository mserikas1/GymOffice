namespace GymOffice.Business.DataProviders;
public class VisitorDataProvider : IVisitorDataProvider
{
    private readonly IVisitorRepository _visitorRepository;

    public VisitorDataProvider(IVisitorRepository visitorRepository)
    {
        _visitorRepository = visitorRepository;
    }

    public async Task<ICollection<Visitor>?> GetAllVisitorsAsync()
    {
        return await _visitorRepository.GetVisitorsAsync();
    }
}
