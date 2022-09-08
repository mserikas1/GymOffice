namespace GymOffice.Common.Contracts.QueryContracts;
public interface IGetCoachByIdQuery
{
    Task<Coach?> Execute(Guid id);
}
