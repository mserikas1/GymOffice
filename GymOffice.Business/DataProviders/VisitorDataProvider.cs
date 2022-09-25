using GymOffice.Business.Common.Exceptions;

namespace GymOffice.Business.DataProviders;
public class VisitorDataProvider : IVisitorDataProvider
{
    private readonly IVisitorRepository _visitorRepository;

    public VisitorDataProvider(IVisitorRepository visitorRepository)
    {
        _visitorRepository = visitorRepository;
    }

    public async Task<ICollection<Visitor>?> GetActiveVisitorsAsync()
    {
        return await _visitorRepository.GetActiveVisitorsAsync();
    }

    public async Task<ICollection<Visitor>?> GetInactiveVisitorsAsync()
    {
        return await _visitorRepository.GetInactiveVisitorsAsync();
    }
    public async Task<ICollection<Visitor>?> GetAllVisitorsAsync()
    {
        return await _visitorRepository.GetVisitorsAsync();
    }

    public async Task<Visitor?> GetVisitorByIdAsync(Guid id)
    {
        return await _visitorRepository.GetVisitorByIdAsync(id);
    }
}
