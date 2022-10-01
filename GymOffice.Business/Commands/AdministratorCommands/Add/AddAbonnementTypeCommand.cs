using GymOffice.Common.DTOs;

namespace GymOffice.Business.Commands.AdministratorCommands.Add;
public class AddAbonnementTypeCommand : IAddAbonnementTypeCommand
{
    private readonly IAbonnementTypeRepository _abonnementTypeRepository;

    public AddAbonnementTypeCommand(IAbonnementTypeRepository abonnementTypeRepository)
    {
        _abonnementTypeRepository = abonnementTypeRepository;
    }

    public async Task ExecuteAsync(AbonnementType type)
    {
        if (type == null)
        {
            throw new ArgumentNullException(nameof(type));
        }
        if (type.Name == null ||
            type.StartVisitTime == null ||
            type.EndVisitTime == null ||
            type.CreatedBy == null ||
            type.ModifiedBy == null)
        {
            throw new RequiredPropertiesNotFilledException();
        }

        if (!TimeSpan.TryParse(type.StartVisitTime, out TimeSpan startTime) ||
            !TimeSpan.TryParse(type.EndVisitTime, out TimeSpan endTime))
        {
            throw new ArgumentOutOfRangeException("\"Start Visit Time\" or \"End Visit Time\" have not correct value");
        }
        if (startTime >= endTime)
        {
            throw new ArgumentException("Start time must be earlier then end time");
        }
        if (await _abonnementTypeRepository.GetByIdAsync(type.Id) != null)
        {
            throw new SameEntityExistsException(nameof(AbonnementType), type.Id);
        }
        
        await _abonnementTypeRepository.AddTypeAsync(type);
    }
}
