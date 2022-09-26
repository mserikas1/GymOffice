<<<<<<< HEAD
﻿namespace GymOffice.Business.DataProviders;
=======
﻿using GymOffice.Business.Common.Exceptions;

namespace GymOffice.Business.DataProviders;
>>>>>>> oleg-feature-receptionist-pages
public class VisitorDataProvider : IVisitorDataProvider
{
    private readonly IVisitorRepository _visitorRepository;

    public VisitorDataProvider(IVisitorRepository visitorRepository)
    {
        _visitorRepository = visitorRepository;
    }

<<<<<<< HEAD
    public async Task<ICollection<Visitor>?> GetAllVisitorsAsync()
    {
        return await _visitorRepository.GetVisitorsAsync();
=======
    public async Task<ICollection<Visitor>?> GetVisitorsInGymAsync()
    {
        return await _visitorRepository.GetVisitorsInGymAsync();
    }

    public async Task<ICollection<Visitor>?> GetVisitorsNotInGymAsync()
    {
        return await _visitorRepository.GetVisitorsNotInGymAsync();
    }
    
    public async Task<ICollection<Visitor>?> GetActiveVisitorsAsync()
    {
        return await _visitorRepository.GetActiveVisitorsAsync();
    }

    public async Task<ICollection<Visitor>?> GetActiveVisitorsNotInGymAsync()
    {
        return await _visitorRepository.GetActiveVisitorsNotInGymAsync();
    }

    public async Task<ICollection<Visitor>?> GetAllVisitorsAsync()
    {
        return await _visitorRepository.GetAllVisitorsAsync();
    }

    public async Task<Visitor?> GetVisitorByIdAsync(Guid id)
    {
        return await _visitorRepository.GetVisitorByIdAsync(id);
>>>>>>> oleg-feature-receptionist-pages
    }
}
