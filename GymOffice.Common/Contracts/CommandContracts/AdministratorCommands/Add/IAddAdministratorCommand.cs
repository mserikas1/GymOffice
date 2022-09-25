namespace GymOffice.Common.Contracts.CommandContracts.AdministratorCommands.Add;
public interface IAddAdministratorCommand
{
    Task<Guid> ExecuteAsync(Admin administrator);
}
