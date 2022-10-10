namespace GymOffice.Common.Contracts.CommandContracts.AdministratorCommands.Add;
public interface IAddAdvantageCommand
{
    Task ExecuteAsync(Advantage advantage);
}
