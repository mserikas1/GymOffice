namespace GymOffice.Common.Contracts.CommandContracts.AdministratorCommands.Add;
public interface IAddAdministratorCommand
{
    Task ExecuteAsync(Admin administrator);
}
