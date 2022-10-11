using GymOffice.Common.Contracts.RepositoryContracts;

namespace GymOffice.Business.Commands.AdministratorCommands.Add;
public class AddCarouselPhotoCommand : IAddCarouselPhotoCommand
{
    private readonly ICarouselPhotoRepository _carouselPhotoRepository;

    public AddCarouselPhotoCommand(ICarouselPhotoRepository carouselPhotoRepository)
    {
        _carouselPhotoRepository = carouselPhotoRepository;
    }

    public async Task ExecuteAsync(CarouselPhoto carouselPhoto)
    {
        if (await _carouselPhotoRepository.GetCarouselPhotoByIdAsync(carouselPhoto.Id) != null)
        {
            throw new SameEntityExistsException(nameof(CarouselPhoto), carouselPhoto.Id);
        }

        await _carouselPhotoRepository.AddCarouselPhotoAsync(carouselPhoto);
    }
}