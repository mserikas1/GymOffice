using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymOffice.Business.DataProviders;
public class CoachDataProvider : ICoachDataProvider
{
    private readonly ICoachRepository _coachRepository;

    public CoachDataProvider(ICoachRepository coachRepository)
    {
        _coachRepository = coachRepository;
    }

    public async Task<ICollection<Coach>?> GetAllCoachesAsync()
    {
        return await _coachRepository.GetAllCoachesAsync();
    }

    public ICollection<Coach> GetCoaches()
    {
        return _coachRepository.GetCoaches();
    }
}
