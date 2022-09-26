using GymOffice.Business.DataProviders;
using GymOffice.Common.Contracts.DataProviderContracts;
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
    public class VisitorRepository : IVisitorRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public VisitorRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddVisitorAsync(Visitor visitor)
        {
            await _dbContext.Visitors.AddAsync(visitor);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<ICollection<Visitor>?> GetVisitorsInGymAsync()
        {
            return await _dbContext.Visitors.Where(v => v.IsInGym).Include(v => v.VisitorCard).ToListAsync();
        }
        public async Task<ICollection<Visitor>?> GetVisitorsNotInGymAsync()
        {
            return await _dbContext.Visitors.Where(v => !v.IsInGym).Include(v => v.VisitorCard).ToListAsync();
        }
        public async Task<ICollection<Visitor>?> GetActiveVisitorsNotInGymAsync()
        {
            return await _dbContext.Visitors.Where(v => v.IsActive && !v.IsInGym).Include(v => v.VisitorCard).ToListAsync();
        }

        public async Task<ICollection<Visitor>?> GetActiveVisitorsAsync()
        {
            return await _dbContext.Visitors.Where(v => v.IsActive).Include(v => v.VisitorCard).ToListAsync();
        }

        public async Task<Visitor?> GetVisitorByIdAsync(Guid id)
        {
            return await _dbContext.Visitors.Include(v => v.VisitorCard).FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task<ICollection<Visitor>?> GetAllVisitorsAsync()
        {
            return await _dbContext.Visitors.Include(v => v.VisitorCard).ToListAsync();
        }

        public async Task UpdateVisitorAsync(Visitor visitor)
        {
            _dbContext.Visitors.Update(visitor);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddVisitorCardAsync(VisitorCard visitorCard)
        {
            _dbContext.VisitorCards.Add(visitorCard);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<VisitorCard?> GetVisitorCardByIdAsync(Guid id)
        {
            return await _dbContext.VisitorCards.FirstOrDefaultAsync(v => v.Id == id);
        }
    }
}
