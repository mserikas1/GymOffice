namespace GymOffice.Common.Contracts.CommandContracts.AdministratorCommands.Edit;
public interface IEditCarouselPhotoCommand
{
    Task ExecuteAsync(CarouselPhoto carouselPhoto);
}
