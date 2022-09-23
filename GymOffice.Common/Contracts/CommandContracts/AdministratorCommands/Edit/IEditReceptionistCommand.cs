namespace GymOffice.Common.Contracts.CommandContracts.AdministratorCommands.Edit;
public interface IEditReceptionistCommand
{
    Task ExecuteAsync(Receptionist receptionist);
}
