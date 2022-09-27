using GymOffice.Common.DTOs;

namespace GymOffice.WebAdmin.Extensions;
public static class DtoConversions
{    
    public static Receptionist ConvertToDto(this ReceptionistVM receptionistVM)
    {
        return new Receptionist
        {
            Id = receptionistVM.Id,
            FirstName = receptionistVM.FirstName,
            LastName = receptionistVM.LastName,
            Email = receptionistVM.Email,
            IsActive = receptionistVM.IsActive,
            PassportNumber = receptionistVM.PassportNumber,
            PhoneNumber = receptionistVM.PhoneNumber,
            PhotoUrl = receptionistVM.PhotoUrl,
            CreatedAt = receptionistVM.CreatedAt,
            CreatedBy = receptionistVM.CreatedBy,
            ModifiedAt = receptionistVM.ModifiedAt,
            ModifiedBy = receptionistVM.ModifiedBy,
            IsAtWork = receptionistVM.IsAtWork,
            JobScheduleItems = receptionistVM.JobScheduleItems
        };
    }

    public static ReceptionistVM ConvertToViewModel(this Receptionist receptionist)
    {
        return new ReceptionistVM
        {
            Id = receptionist.Id,
            FirstName = receptionist.FirstName,
            LastName = receptionist.LastName,
            PhoneNumber = receptionist.PhoneNumber,
            Email = receptionist.Email,
            PassportNumber = receptionist.PassportNumber,
            IsActive = receptionist.IsActive,
            IsAtWork = receptionist.IsAtWork,
            CreatedAt = receptionist.CreatedAt,
            CreatedBy = receptionist.CreatedBy,
            ModifiedAt = receptionist.ModifiedAt,
            ModifiedBy = receptionist.ModifiedBy,
            PhotoUrl = receptionist.PhotoUrl,
            JobScheduleItems = receptionist.JobScheduleItems,
            Password = "qwerty123",             // Fake data for model validation. TODO: real data should take from identity dbContext
            PasswordConfirm = "qwerty123"       // Fake data for model validation. TODO: real data should take from identity dbContext
        };
    }

    public static Visitor ConvertToDto(this VisitorVM visitorVM, VisitorCard visitorCard)
    {
        Visitor visitor = new()
        {
            Id = visitorVM.Id,
            FirstName = visitorVM.FirstName,
            LastName = visitorVM.LastName,
            Email = visitorVM.Email,
            IsActive = visitorVM.IsActive,
            IsInGym = visitorVM.IsInGym,
            RegistrationDate = visitorVM.RegistrationDate,
            PhoneNumber = visitorVM.PhoneNumber,
            PhotoUrl = visitorVM.PhotoUrl,
        };
        visitor.VisitorCard = visitorCard;
        visitorCard.Visitor = visitor;
        return visitor;
    }

}
