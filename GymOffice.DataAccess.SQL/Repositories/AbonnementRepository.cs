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

        public async Task<ICollection<Abonnement>?> GetActiveAsync()
        {
            return await _dbContext.Abonnements.Where(a => a.IsActive == true)
                .Include(a => a.AbonnementType)
                .Include(a => a.VisitorCard)
                .ThenInclude(vc => vc.Visitor)
                .ToListAsync();
        }

        public ICollection<Abonnement>? GetAll()
        {
            return _dbContext.Abonnements
                .Include(a => a.AbonnementType)
                .Include(a => a.VisitorCard)
                .ThenInclude(vc => vc.Visitor)
                .ToList();
        }

        public async Task<ICollection<Abonnement>?> GetAllAsync()
        {
            return await _dbContext.Abonnements
                .Include(a => a.AbonnementType)
                .Include(a => a.VisitorCard)
                .ThenInclude(vc => vc.Visitor)
                .ToListAsync();
        }

        public async Task<ICollection<Abonnement>?> SearchAbonnementsAsync(AbonnementSearchOptions options)
        {
            var abonnements = _dbContext.Abonnements
                .Include(a => a.AbonnementType)
                .Include(a => a.VisitorCard)
                .ThenInclude(vc => vc.Visitor)
                .AsEnumerable();

            if (!string.IsNullOrEmpty(options.Type) && options.Type != "All")
                abonnements = abonnements.Where(a => a.AbonnementType.Name.Equals(options.Type, StringComparison.InvariantCultureIgnoreCase));
            if (!string.IsNullOrEmpty(options.Duration) && options.Duration != "All")
                abonnements = abonnements.Where(a => a.AbonnementType.Duration.ToString().Equals(options.Duration, StringComparison.InvariantCultureIgnoreCase));
            if (options.IsActive == SelectedItem.Selected)
                abonnements = abonnements.Where(a => a.IsActive == true);
            if (options.IsActive == SelectedItem.Unselected)
                abonnements = abonnements.Where(a => a.IsActive == false);
            if (options.EndPrice != 0)
                abonnements = abonnements.Where(a => a.SoldPrice >= options.StartPrice && a.SoldPrice <= options.EndPrice);

            abonnements = abonnements.Where(a => a.IssueTime.Day >= options.StartDay?.Day && a.IssueTime.Day <= options.EndDay?.Day);
            

            return await Task.FromResult(abonnements.ToList());
        }
    }
}
