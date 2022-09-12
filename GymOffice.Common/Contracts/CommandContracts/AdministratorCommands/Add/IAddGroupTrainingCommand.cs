namespace GymOffice.Common.Contracts.CommandContracts.AdministratorCommands.Add;
public interface IAddGroupTrainingCommand
{
    Task<Guid> ExecuteAsync(GroupTraining groupTraining);
}
