using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymOffice.Common.Contracts.DataProviderContracts;
public interface ICoachDataProvider
{
    ICollection<Coach>? GetActiveCoaches();
}
