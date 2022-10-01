namespace GymOffice.Common.Contracts.CommandContracts.AdministratorCommands.Add;
public interface IAddAbonnementTypeCommand
{
    Task ExecuteAsync(AbonnementType abonnementType);
}
