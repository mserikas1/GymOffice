namespace GymOffice.Common.Contracts.CommandContracts.AdministratorCommands.Delete;
public interface IDeleteGroupTraining
{
    Task<GroupTraining> ExecuteAsync(Guid Id);
}
