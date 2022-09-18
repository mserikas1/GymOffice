namespace GymOffice.Common.Contracts.CommandContracts.AdministratorCommands.Add;
public interface IAddReceptionistCommand
{
    Task ExecuteAsync(Receptionist receptionist);
}
