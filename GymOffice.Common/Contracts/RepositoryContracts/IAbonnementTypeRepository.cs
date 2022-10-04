namespace GymOffice.Common.Contracts.RepositoryContracts;
    public interface IAbonnementTypeRepository
    {
    Task AddTypeAsync(AbonnementType type);
    Task<ICollection<AbonnementType>?> GetActiveTypesAsync();
    Task<ICollection<AbonnementType>?> GetAllTypesAsync();
    Task<AbonnementType?> GetByIdAsync(Guid id);
    Task UpdateTypeAsync(AbonnementType type);
    ICollection<AbonnementType>? GetActiveAbonnementTypes();
}
