namespace GymOffice.Business.Commands.AdministratorCommands.Edit;
public class EditCarouselPhotoCommand : IEditCarouselPhotoCommand
{
    private readonly ICarouselPhotoRepository _carouselPhotoRepository;

    public EditCarouselPhotoCommand(ICarouselPhotoRepository carouselPhotoRepository)
    {
        _carouselPhotoRepository = carouselPhotoRepository;
    }

    public async Task ExecuteAsync(CarouselPhoto carouselPhoto)
    {
        if (carouselPhoto == null)
        {
            return;
        }
        if (string.IsNullOrWhiteSpace(carouselPhoto.PhotoUrl))
        {
            throw new RequiredPropertiesNotFilledException();
        }
        CarouselPhoto? entity = await _carouselPhotoRepository.GetCarouselPhotoByIdAsync(carouselPhoto.Id);
        if (entity == null || entity.Id != carouselPhoto.Id)
        {
            throw new NotFoundException(nameof(CarouselPhoto), carouselPhoto.Id);
        }
        await _carouselPhotoRepository.UpdateCarouselPhotoAsync(carouselPhoto);
    }
}