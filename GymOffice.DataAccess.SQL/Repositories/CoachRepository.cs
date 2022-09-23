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
    public class CoachRepository : ICoachRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CoachRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ICollection<Coach>?> GetAllCoachesAsync()
        {
            return await _dbContext.Coaches.ToListAsync();
        }

        public ICollection<Coach> GetCoaches()
        {
            return _dbContext.Coaches.ToList();
        }
    }
}
