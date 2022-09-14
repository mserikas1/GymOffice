namespace GymOffice.Common.Contracts.CommandContracts.AbonnementCommands;
public interface IHandleExpiredAbonnementCommand
{
    Task ExecuteAsync(Abonnement abonnement);
}
