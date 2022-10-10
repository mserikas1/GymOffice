namespace GymOffice.Common.Contracts.DataProviderContracts
{
    public interface ICarouselPhotoDataProvider
    {
        Task<CarouselPhoto?> GetCarouselPhotoByIdAsync(int id);
        Task<ICollection<CarouselPhoto>?> GetAllCarouselPhotosAsync();
    }
}
