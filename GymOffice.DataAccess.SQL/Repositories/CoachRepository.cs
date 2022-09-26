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

        public async Task<Guid> AddCoachAsync(Coach coach)
        {
            await _dbContext.Coaches.AddAsync(coach);
            await _dbContext.SaveChangesAsync();
            return coach.Id;
        }

        public async Task<ICollection<Coach>?> GetActiveCoachesAsync()
        {
            return await _dbContext.Coaches.Where(c => c.IsAtWork).ToListAsync();
        }

        public async Task<ICollection<Coach>?> GetCoachesNotAtWorkAsync()
        {
            return await _dbContext.Coaches.Where(c => !c.IsAtWork).ToListAsync();
        }

        public async Task<ICollection<Coach>?> GetAllCoachesAsync()
        {
            return await _dbContext.Coaches.ToListAsync();
        }

        public async Task<Coach?> GetCoachByIdAsync(Guid id)
        {
            return await _dbContext.Coaches.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task UpdateCoachAsync(Coach coach)
        {
            _dbContext.Coaches.Update(coach);
            await _dbContext.SaveChangesAsync();
        }
    }
}
