using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymOffice.Business.DataProviders
{
    public class AbonnementDataProvider : IAbonnementDataProvider
    {
        private readonly IAbonnementRepository _abonnementRepository;
        public AbonnementDataProvider(IAbonnementRepository abonnementRepository)
        {
            _abonnementRepository = abonnementRepository;
        }
        public ICollection<Abonnement>? GetAbonnementsById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
