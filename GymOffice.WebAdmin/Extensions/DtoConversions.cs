using GymOffice.WebAdmin.ViewModels;

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

    public static Coach ConvertToDto(this CoachVM coachVM)
    {
        return new Coach
        {
            Id = coachVM.Id,
            FirstName = coachVM.FirstName,
            LastName = coachVM.LastName,
            Email = coachVM.Email,
            IsActive = coachVM.IsActive,
            PassportNumber = coachVM.PassportNumber,
            PhoneNumber = coachVM.PhoneNumber,
            PhotoUrl = coachVM.PhotoUrl,
            CreatedAt = coachVM.CreatedAt,
            CreatedBy = coachVM.CreatedBy,
            ModifiedAt = coachVM.ModifiedAt,
            ModifiedBy = coachVM.ModifiedBy,
            IsAtWork = coachVM.IsAtWork,
            JobScheduleItems = coachVM.JobScheduleItems,
            Education = coachVM.Education,
            Description = coachVM.Description,
            GroupTrainings = coachVM.GroupTrainings,
            PersonalTrainings = coachVM.PersonalTrainings
        };
    }

    public static CoachVM ConvertToViewModel(this Coach coach)
    {
        return new CoachVM
        {
            Id = coach.Id,
            FirstName = coach.FirstName,
            LastName = coach.LastName,
            Email = coach.Email,
            IsActive = coach.IsActive,
            PassportNumber = coach.PassportNumber,
            PhoneNumber = coach.PhoneNumber,
            PhotoUrl = coach.PhotoUrl,
            CreatedAt = coach.CreatedAt,
            CreatedBy = coach.CreatedBy,
            ModifiedAt = coach.ModifiedAt,
            ModifiedBy = coach.ModifiedBy,
            IsAtWork = coach.IsAtWork,
            JobScheduleItems = coach.JobScheduleItems,
            Education = coach.Education,
            Description = coach.Description,
            GroupTrainings = coach.GroupTrainings,
            PersonalTrainings = coach.PersonalTrainings,
            Password = "qwerty123",             // Fake data for model validation. TODO: real data should take from identity dbContext
            PasswordConfirm = "qwerty123"       // Fake data for model validation. TODO: real data should take from identity dbContext
        };
    }
}
