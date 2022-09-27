using GymOffice.Common.Contracts.RepositoryContracts;
using GymOffice.Common.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymOffice.DataAccess.SQL.Repositories
{
    public class AbonnementTypeRepository : IAbonnementTypeRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public AbonnementTypeRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ICollection<AbonnementType>? GetActiveAbonnementTypes()
        {
            return _dbContext.AbonnementTypes.Where(abonnement => abonnement.IsActive == true).ToList();
        }
    }
}
