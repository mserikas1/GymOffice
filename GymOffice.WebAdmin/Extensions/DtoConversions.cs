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

    public static AbonnementType ConvertToDto(this AbonnementTypeVM abonnementTypeVM)
    {
        return new AbonnementType
        {
            Id = abonnementTypeVM.Id,
            Name = abonnementTypeVM.Name,
            Price = abonnementTypeVM.Price,
            Duration = abonnementTypeVM.Duration,
            IsActive = abonnementTypeVM.IsActive,
            CreatedAt = abonnementTypeVM.CreatedAt,
            ModifiedAt = abonnementTypeVM.ModifiedAt,
            CreatedBy = abonnementTypeVM.CreatedBy,
            ModifiedBy = abonnementTypeVM.ModifiedBy,
            Description = abonnementTypeVM.Description,
            Abonnements = abonnementTypeVM.Abonnements,
            StartVisitTime = abonnementTypeVM.StartVisitTime == null ? "00:00" : abonnementTypeVM.StartVisitTime.Value.ToString(@"hh\:mm"),
            EndVisitTime = abonnementTypeVM.EndVisitTime == null ? "00:00" : abonnementTypeVM.EndVisitTime.Value.ToString(@"hh\:mm")
        };
    }

    public static AbonnementTypeVM ConvertToViewModel(this AbonnementType abonnementType)
    {
        return new AbonnementTypeVM
        {
            Id = abonnementType.Id,
            Name = abonnementType.Name,
            Price = abonnementType.Price,
            Duration = abonnementType.Duration,
            Description = abonnementType.Description,
            IsActive = abonnementType.IsActive,
            CreatedAt = abonnementType.CreatedAt,
            CreatedBy = abonnementType.CreatedBy,
            ModifiedAt = abonnementType.ModifiedAt,
            ModifiedBy = abonnementType.ModifiedBy,
            Abonnements = abonnementType.Abonnements,
            StartVisitTime = TimeSpan.Parse(abonnementType.StartVisitTime),
            EndVisitTime = TimeSpan.Parse(abonnementType.EndVisitTime)
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

    public static VisitorVM ConvertToViewModel(this Visitor visitor)
    {
        return new VisitorVM
        {
            Id = visitor.Id,
            FirstName = visitor.FirstName!,
            LastName = visitor.LastName!,
            Email = visitor.Email ?? "",
            PhoneNumber = visitor.PhoneNumber ?? "",
            IsActive = visitor.IsActive,
            IsInGym = visitor.IsInGym,
            PhotoUrl = visitor.PhotoUrl,
            RegistrationDate = visitor.RegistrationDate,
            VisitorCard = visitor.VisitorCard,
            VisitorCardId = visitor.VisitorCardId
        };
    }
    public static Advantage ConvertToDto(this AdvantageVM advantageVM)
    {
        Advantage advantage = new()
        {
            Id = advantageVM.Id,
            Title = advantageVM.Title,
            Description = advantageVM.Description,
            PhotoUrl = advantageVM.PhotoUrl,
            CreatedAt = advantageVM.CreatedAt,
            CreatedBy = advantageVM.CreatedBy,
            ModifiedAt = advantageVM.ModifiedAt,
            ModifiedBy = advantageVM.ModifiedBy
        };
        return advantage;
    }
    public static AdvantageVM ConvertToViewModel(this Advantage advantage)
    {
        AdvantageVM advantageVM = new()
        {
            Id = advantage.Id,
            Title = advantage.Title,
            Description = advantage.Description,
            PhotoUrl = advantage.PhotoUrl,
            CreatedBy = advantage.CreatedBy,
            ModifiedAt = advantage.ModifiedAt,
            CreatedAt = advantage.CreatedAt,
            ModifiedBy = advantage.ModifiedBy
        };
        return advantageVM;
    }
}
