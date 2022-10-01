namespace GymOffice.Common.Contracts.CommandContracts.AdministratorCommands.Edit;
public interface IEditAbonnementTypeCommand
{
    Task ExecuteAsync(AbonnementType abonnementType);
}
