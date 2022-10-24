using AutoFixture;

namespace GymOffice.UnitTests.Common;
public abstract class TestReceptionistCommandsBase
{
    protected static Guid EXISTING_GUID = Guid.Parse("82f70309-d688-4642-d7f1-08da9f146849");
    protected static string EXISTING_EMAIL = "sandra.b@hollywood.us";
    protected static Guid UNIQUE_GUID = Guid.Parse("A708726B-D803-4DF8-A28C-A79EE4874EB6");
    protected Mock<IVisitorRepository> _mockVisitorRepo;

    public Visitor ExistingVisitor { get; private set; } = null!;
    public Visitor UniqueVisitor { get; private set; } = null!;
    public Visitor VisitorWithEmptyName { get; private set; } = null!;
    public Visitor VisitorWithExistingEmail { get; private set; } = null!;
    public Admin ExistingAdmin { get; private set; } = null!;

    public TestReceptionistCommandsBase()
    {
        _mockVisitorRepo = new Mock<IVisitorRepository>();

        CreateEntities();
    }

    private void CreateEntities()
    {
        ExistingAdmin = new Admin
        {
            Id = Guid.NewGuid(),
            FirstName = "FirstNameAdmin",
            LastName = "LastNameAdmin",
            Email = "admin2@test.com",
            IsActive = true,
            PassportNumber = "SS789456",
            PhoneNumber = "+380333956456",
            PhotoUrl = null
        };
        ExistingVisitor = new Visitor
        {
            Id = EXISTING_GUID,
            FirstName = "FirstNameVisitor1",
            LastName = "LastNameVisitor1",
            Email = "Visitor1@test.com",
            IsActive = true,
            PhoneNumber = "+380333456406",
            PhotoUrl = null,
            IsInGym = false            
        };
        VisitorWithExistingEmail = new Visitor
        {
            Id = Guid.NewGuid(),
            FirstName = "FirstNameVisitor2",
            LastName = "LastNameVisitor2",
            Email = EXISTING_EMAIL,
            IsActive = true,
            PhoneNumber = "+380333432406",
            PhotoUrl = null,
            IsInGym = false
        };
        UniqueVisitor = new Visitor
        {
            Id = UNIQUE_GUID,
            FirstName = "FirstNameVisitor3",
            LastName = "LastNameVisitor3",
            Email = "Visitor3@test.com",
            IsActive = true,
            PhoneNumber = "+380333456408",
            PhotoUrl = null,
            IsInGym = false
        };
        VisitorWithEmptyName = new Visitor
        {
            Id = Guid.NewGuid(),
            FirstName = "",
            LastName = "LastNameVisitor3",
            Email = "Visitor3@test.com",
            IsActive = true,
            PhoneNumber = "+380333456568",
            PhotoUrl = null,
            IsInGym = false
        };
    }
}
