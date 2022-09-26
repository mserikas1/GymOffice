<<<<<<< HEAD
﻿namespace GymOffice.Business.Commands.AdministratorCommands.Add;
=======
﻿using GymOffice.Business.Common.Exceptions;
using GymOffice.Common.Contracts.CommandContracts.AdministratorCommands.Add;

namespace GymOffice.Business.Commands.AdministratorCommands.Add;
>>>>>>> oleg-feature-receptionist-pages
public class AddReceptionistCommand : IAddReceptionistCommand
{
    private readonly IEmployeeRepository _employeeRepository;

    public AddReceptionistCommand(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task ExecuteAsync(Receptionist receptionist)
    {
        if (receptionist == null)
        {
            return;
        }
        if (string.IsNullOrWhiteSpace(receptionist.FirstName) ||
            string.IsNullOrWhiteSpace(receptionist.LastName) ||
            string.IsNullOrWhiteSpace(receptionist.Email) ||
            string.IsNullOrWhiteSpace(receptionist.PhoneNumber) ||
            receptionist.CreatedBy == null ||
            receptionist.ModifiedBy == null)
        {
            throw new RequiredPropertiesNotFilledException();
        }
        if (await _employeeRepository.GetReceptionistByIdAsync(receptionist.Id) != null)
        {
            throw new SameEntityExistsException(nameof(Receptionist), receptionist.Id);
        }

        await _employeeRepository.AddReceptionistAsync(receptionist);
    }
}