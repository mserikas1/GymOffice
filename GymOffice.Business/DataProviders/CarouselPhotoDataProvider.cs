using GymOffice.Common.Contracts.RepositoryContracts;

namespace GymOffice.Business.DataProviders
{
    public class CarouselPhotoDataProvider : ICarouselPhotoDataProvider
    {
        private readonly ICarouselPhotoRepository _carouselPhotoRepository;

        public CarouselPhotoDataProvider(ICarouselPhotoRepository carouselPhotoRepository)
        {
            _carouselPhotoRepository = carouselPhotoRepository;
        }

        public async Task<CarouselPhoto?> GetCarouselPhotoByIdAsync(int id)
        {
            CarouselPhoto? entity = await _carouselPhotoRepository.GetCarouselPhotoByIdAsync(id);

            if (entity == null || entity.Id != id)
            {
                throw new NotFoundException(nameof(CarouselPhoto), id);
            }

            return entity;
        }

        public async Task<ICollection<CarouselPhoto>?> GetAllCarouselPhotosAsync()
        {
            return await _carouselPhotoRepository.GetAllCarouselPhotosAsync();
        }
    }
}
