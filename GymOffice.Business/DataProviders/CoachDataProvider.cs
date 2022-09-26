<<<<<<< HEAD
﻿namespace GymOffice.Business.DataProviders;
=======
﻿using GymOffice.Business.Common.Exceptions;

namespace GymOffice.Business.DataProviders;
>>>>>>> oleg-feature-receptionist-pages
public class CoachDataProvider : ICoachDataProvider
{
    private readonly ICoachRepository _coachRepository;

    public CoachDataProvider(ICoachRepository coachRepository)
    {
        _coachRepository = coachRepository;
    }

<<<<<<< HEAD
=======
    public async Task<ICollection<Coach>?> GetCoachesAtWorkAsync()
    {
        return await _coachRepository.GetCoachesAtWorkAsync();
    }
    
    public async Task<ICollection<Coach>?> GetActiveCoachesNotAtWorkAsync()
    {
        return await _coachRepository.GetActiveCoachesNotAtWorkAsync();
    }
    public async Task<ICollection<Coach>?> GetCoachesNotAtWorkAsync()
    {
        return await _coachRepository.GetCoachesNotAtWorkAsync();
    }

>>>>>>> oleg-feature-receptionist-pages
    public async Task<ICollection<Coach>?> GetAllCoachesAsync()
    {
        return await _coachRepository.GetAllCoachesAsync();
    }
<<<<<<< HEAD
=======

    public async Task<ICollection<Coach>?> GetActiveCoachesAsync()
    {
        return await _coachRepository.GetActiveCoachesAsync();
    }

    public async Task<Coach?> GetCoachByIdAsync(Guid id)
    {        
        Coach? entity = await _coachRepository.GetCoachByIdAsync(id);

        if (entity == null || entity.Id != id)
        {
            throw new NotFoundException(nameof(Coach), id);
        }

        return entity;
    }
>>>>>>> oleg-feature-receptionist-pages
}
