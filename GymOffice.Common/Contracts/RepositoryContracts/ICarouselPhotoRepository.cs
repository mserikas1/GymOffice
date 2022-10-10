namespace GymOffice.Common.Contracts.RepositoryContracts
{
    public interface ICarouselPhotoRepository
    {
        Task<CarouselPhoto?> GetCarouselPhotoByIdAsync(int id);
        Task<ICollection<CarouselPhoto>?> GetAllCarouselPhotosAsync();
        Task AddCarouselPhotoAsync(CarouselPhoto photo);
        Task UpdateCarouselPhotoAsync(CarouselPhoto photo);
        Task DeleteCarouselPhotoAsync(CarouselPhoto photo);
    }
}
