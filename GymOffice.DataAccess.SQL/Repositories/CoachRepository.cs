namespace GymOffice.DataAccess.SQL.Repositories
{
    public class CoachRepository : ICoachRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CoachRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddCoachAsync(Coach coach)
        {
            await _dbContext.Coaches.AddAsync(coach);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<ICollection<Coach>?> GetActiveCoachesAsync()
        {
            return await _dbContext.Coaches.Where(c => c.IsActive).ToListAsync();
        }

        public async Task<ICollection<Coach>?> GetCoachesNotAtWorkAsync()
        {
            return await _dbContext.Coaches.Where(c => !c.IsAtWork).ToListAsync();
        }
        public async Task<ICollection<Coach>?> GetCoachesAtWorkAsync()
        {
            return await _dbContext.Coaches.Where(c => c.IsAtWork).ToListAsync();
        }

        public async Task<ICollection<Coach>?> GetActiveCoachesNotAtWorkAsync()
        {
            return await _dbContext.Coaches.Where(c => c.IsActive && !c.IsAtWork).ToListAsync();
        }
        public async Task<ICollection<Coach>?> GetAllCoachesAsync()
        {
            return await _dbContext.Coaches
                .Include(c => c.CreatedBy)
                .Include(c => c.ModifiedBy)
                .ToListAsync();
        }

        public async Task<Coach?> GetCoachByIdAsync(Guid id)
        {
            return await _dbContext.Coaches.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task UpdateCoachAsync(Coach coach)
        {
            Coach? entity = await _dbContext.Coaches
            .SingleOrDefaultAsync(r => r.Id == coach.Id);
            if (entity != null)
            {
                entity.PhoneNumber = coach.PhoneNumber;
                entity.Email = coach.Email;
                entity.IsActive = coach.IsActive;
                entity.ModifiedBy = coach.ModifiedBy;
                entity.ModifiedAt = coach.ModifiedAt;
                entity.PhotoUrl = coach.PhotoUrl;
                entity.Education = coach.Education;
                entity.Description = coach.Description;
                _dbContext.Coaches.Update(entity);
                await _dbContext.SaveChangesAsync();
            }
            //_dbContext.Coaches.Update(coach);
            //await _dbContext.SaveChangesAsync();
        }

        public async Task<ICollection<Coach>?> SearchCoachesAsync(CoachSearchOptions options)
        {
            var coaches = _dbContext.Coaches
            .Include(r => r.CreatedBy)
            .Include(r => r.ModifiedBy).AsEnumerable();

            if (!string.IsNullOrEmpty(options.FirstName))
                coaches = coaches.Where(r => r.FirstName.Contains(options.FirstName, StringComparison.InvariantCultureIgnoreCase));
            if (!string.IsNullOrEmpty(options.LastName))
                coaches = coaches.Where(r => r.LastName.Contains(options.LastName, StringComparison.InvariantCultureIgnoreCase));
            if (!string.IsNullOrEmpty(options.Email))
                coaches = coaches.Where(r => r.Email.Contains(options.Email, StringComparison.InvariantCultureIgnoreCase));
            if (!string.IsNullOrEmpty(options.Phone))
                coaches = coaches.Where(r => r.PhoneNumber.Contains(options.Phone, StringComparison.InvariantCultureIgnoreCase));
            if (options.IsActive == SelectedIItem.Selected)
                coaches = coaches.Where(r => r.IsActive == true);
            if (options.IsActive == SelectedIItem.Unselected)
                coaches = coaches.Where(r => r.IsActive == false);
            if (options.IsAtWork == SelectedIItem.Selected)
                coaches = coaches.Where(r => r.IsAtWork == true);
            if (options.IsAtWork == SelectedIItem.Unselected)
                coaches = coaches.Where(r => r.IsAtWork == false);
            if (options.HasGroupTraining == SelectedIItem.Selected)
                coaches = coaches.Where(r => r.GroupTrainings.Any());
            if (options.HasGroupTraining == SelectedIItem.Unselected)
                coaches = coaches.Where(r => r.GroupTrainings == null || r.GroupTrainings.Any() == false);

            return await Task.FromResult(coaches.ToList());
        }
    }
}
