using GymOffice.Common.Utilities.Enums;

namespace GymOffice.Common.DTOs;
public class Receptionist : Employee
{
    public override Role Role { get; set; } = Role.Receptionist;
}
