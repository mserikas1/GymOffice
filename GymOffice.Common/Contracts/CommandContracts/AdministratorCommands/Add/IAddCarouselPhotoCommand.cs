namespace GymOffice.Common.Contracts.CommandContracts.AdministratorCommands.Add;
public interface IAddCarouselPhotoCommand
{
    Task ExecuteAsync(CarouselPhoto carouselPhoto);
}
