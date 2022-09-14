namespace GymOffice.Common.Contracts.CommandContracts.AbonnementCommands;
public interface IActivateAbonnementCommand
{
    Task ExecuteAsync(Abonnement abonnement);
}
