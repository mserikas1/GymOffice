namespace GymOffice.Common.Contracts.CommandContracts.AdministratorCommands.Edit;
public interface IEditAdvantageCommand
{
    Task ExecuteAsync(Advantage advantage);
}
