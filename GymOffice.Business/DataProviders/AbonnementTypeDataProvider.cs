using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymOffice.Business.DataProviders
{
    public class AbonnementTypeDataProvider : IAbonnementTypeDataProvider
    {
        private readonly IAbonnementTypeRepository _abonnementTypeRepository;
        public AbonnementTypeDataProvider(IAbonnementTypeRepository abonnementTypeRepository)
        {
            _abonnementTypeRepository = abonnementTypeRepository;
        }

        public ICollection<AbonnementType>? GetActiveAbonnementTypes()
        {
            return _abonnementTypeRepository.GetActiveAbonnementTypes();
        }
    }
}
