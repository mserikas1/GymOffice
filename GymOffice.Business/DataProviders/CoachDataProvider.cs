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

    public ICollection<Coach>? GetActiveCoaches()
    {
        return _coachRepository.GetActiveCoaches();
    }
}
