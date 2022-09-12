namespace GymOffice.Common.Contracts.CommandContracts.EmployeeCommands.Add;
public interface IAddAbonnementCommand
{
    Task<Guid> ExecuteAsync(Abonnement abonnement);
}
