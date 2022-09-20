namespace GymOffice.WebAdmin.Extensions;
public static class DtoConversions
{    
    public static Receptionist ConvertToDto(this CreatedReceptionistVM receptionistVM)
    {
        return new Receptionist
        {
            Id = Guid.NewGuid(),
            FirstName = receptionistVM.FirstName,
            LastName = receptionistVM.LastName,
            Email = receptionistVM.Email,
            IsActive = true,
            PassportNumber = receptionistVM.PassportNumber,
            PhoneNumber = receptionistVM.PhoneNumber,
            PhotoUrl = receptionistVM.PhotoUrl,
            CreatedAt = DateTime.Now,
            CreatedBy = receptionistVM.CreatedBy,
            ModifiedAt = DateTime.Now,
            ModifiedBy = receptionistVM.ModifiedBy,
            IsAtWork = false,
            JobScheduleItems = new List<JobSchedule>()
        };
    }
}
