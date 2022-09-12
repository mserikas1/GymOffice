namespace GymOffice.Common.Contracts.CommandContracts.AdministratorCommands.Add;
public interface IAddReceptionistCommand
{
    Task<Guid> ExecuteAsync(Receptionist receptionist);
}
