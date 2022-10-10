using GymOffice.Common.Contracts.CommandContracts.AdministratorCommands.Delete;

namespace GymOffice.Business.Commands.AdministratorCommands.Delete;
public class DeleteCarouselPhotoCommand : IDeleteCarouselPhotoCommand
{
    private readonly ICarouselPhotoRepository _carouselPhotoRepository;

    public DeleteCarouselPhotoCommand(ICarouselPhotoRepository carouselPhotoRepository)
    {
        _carouselPhotoRepository = carouselPhotoRepository;
    }

    public async Task ExecuteAsync(CarouselPhoto carouselPhoto)
    {
        if (carouselPhoto == null)
        {
            return;
        }
        CarouselPhoto? entity = await _carouselPhotoRepository.GetCarouselPhotoByIdAsync(carouselPhoto.Id);
        if (entity == null || entity.Id != carouselPhoto.Id)
        {
            throw new NotFoundException(nameof(CarouselPhoto), carouselPhoto.Id);
        }
        await _carouselPhotoRepository.DeleteCarouselPhotoAsync(carouselPhoto);
    }
}