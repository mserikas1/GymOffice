namespace GymOffice.Common.Contracts.CommandContracts.AdministratorCommands.Add;
public interface IAddAbonnementTypeCommand
{
    Task<Guid> ExecuteAsync(AbonnementType abonnementType);
}
