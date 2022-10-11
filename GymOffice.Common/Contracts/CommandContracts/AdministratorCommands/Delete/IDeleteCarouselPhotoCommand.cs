using GymOffice.Common.Contracts.RepositoryContracts;

namespace GymOffice.Common.Contracts.CommandContracts.AdministratorCommands.Delete;
public interface IDeleteCarouselPhotoCommand
{
    Task ExecuteAsync(CarouselPhoto carouselPhoto);
}