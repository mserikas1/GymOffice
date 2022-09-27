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
    public class AbonnementRepository : IAbonnementRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public AbonnementRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ICollection<Abonnement>? GetAbonnementsById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
