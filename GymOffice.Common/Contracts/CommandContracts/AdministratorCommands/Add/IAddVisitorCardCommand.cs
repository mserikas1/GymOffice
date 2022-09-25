namespace GymOffice.Common.Contracts.CommandContracts.AdministratorCommands.Add;
public interface IAddVisitorCardCommand
{
    Task ExecuteAsync(VisitorCard visitorCard);
}
