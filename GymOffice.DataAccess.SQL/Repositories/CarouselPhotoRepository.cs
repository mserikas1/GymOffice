using GymOffice.Business.Common.Exceptions;
using GymOffice.Common.Contracts.RepositoryContracts;
using GymOffice.Common.DTOs;

namespace GymOffice.DataAccess.SQL.Repositories
{
    public class CarouselPhotoRepository : ICarouselPhotoRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public CarouselPhotoRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CarouselPhoto?> GetCarouselPhotoByIdAsync(int id)
        {
            return await _dbContext.CarouselPhotos.SingleOrDefaultAsync(f => f.Id == id);
        }

        public async Task<ICollection<CarouselPhoto>?> GetAllCarouselPhotosAsync()
        {
            return await _dbContext.CarouselPhotos.ToListAsync();
        }

        public async Task AddCarouselPhotoAsync(CarouselPhoto photo)
        {
            await _dbContext.CarouselPhotos.AddAsync(photo);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateCarouselPhotoAsync(CarouselPhoto photo)
        {
            _dbContext.CarouselPhotos.Update(photo);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteCarouselPhotoAsync(CarouselPhoto photo)
        {
            _dbContext.CarouselPhotos.Remove(photo);
            await _dbContext.SaveChangesAsync();
        }
    }
}
