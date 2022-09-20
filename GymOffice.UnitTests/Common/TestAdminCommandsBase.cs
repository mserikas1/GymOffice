using AutoFixture;

namespace GymOffice.UnitTests.Common;
public abstract class TestAdminCommandsBase
{
    protected static Guid EXISTING_GUID = Guid.Parse("25B3D710-537B-4126-8C57-1763881C990A");
    protected static Guid UNIQUE_GUID = Guid.Parse("A708726B-D803-4DF8-A28C-A79EE4874EB6");
    protected Mock<IEmployeeRepository> _mockEmployeeRepo;

    public Receptionist ExistingReceptionist { get; private set; } = null!;
    public Receptionist UniqueReceptionist { get; private set; } = null!;
    public Receptionist ReceptionistWithEmptyName { get; private set; } = null!;
    public Admin ExistingAdmin { get; private set; } = null!;

    public TestAdminCommandsBase()
    {
        _mockEmployeeRepo = new Mock<IEmployeeRepository>();

        CreateEntities();
    }

    private void CreateEntities()
    {
        ExistingAdmin = new Admin
        {
            Id = Guid.NewGuid(),
            FirstName = "FirstNameAdmin",
            LastName = "LastNameAdmin",
            Email = "admin@test.com",
            IsActive = true,
            PassportNumber = "ЯЧ789456",
            PhoneNumber = "0333456456",
            PhotoUrl = null
        };
        ExistingReceptionist = new Receptionist
        {
            Id = EXISTING_GUID,
            FirstName = "FirstNameReceptionist1",
            LastName = "LastNameReceptionist1",
            Email = "receptionist1@test.com",
            IsActive = true,
            PassportNumber = "ЯЧ789401",
            PhoneNumber = "0333456401",
            PhotoUrl = null,
            CreatedAt = DateTime.Now,
            CreatedBy = ExistingAdmin,
            ModifiedBy = ExistingAdmin,
            ModifiedAt = DateTime.Now,
            IsAtWork = false            
        };
        UniqueReceptionist = new Receptionist
        {
            Id = UNIQUE_GUID,
            FirstName = "FirstNameReceptionist2",
            LastName = "LastNameReceptionist2",
            Email = "receptionist2@test.com",
            IsActive = true,
            PassportNumber = "ЯЧ789402",
            PhoneNumber = "0333456402",
            PhotoUrl = null,
            CreatedAt = DateTime.Now,
            CreatedBy = ExistingAdmin,
            ModifiedBy = ExistingAdmin,
            ModifiedAt = DateTime.Now,
            IsAtWork = false
        };
        ReceptionistWithEmptyName = new Receptionist
        {
            Id = UNIQUE_GUID,
            FirstName = "",
            LastName = "LastNameReceptionist3",
            Email = "receptionist2@test.com",
            IsActive = true,
            PassportNumber = "ЯЧ789402",
            PhoneNumber = "0333456402",
            PhotoUrl = null,
            CreatedAt = DateTime.Now,
            CreatedBy = ExistingAdmin,
            ModifiedBy = ExistingAdmin,
            ModifiedAt = DateTime.Now,
            IsAtWork = false
        };
    }
}
