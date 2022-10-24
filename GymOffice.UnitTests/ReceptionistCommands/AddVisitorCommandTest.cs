using GymOffice.Business.Commands.EmployeeCommands.Add;

namespace GymOffice.UnitTests.ReceptionistCommands;
public class AddVisitorCommandTests : TestReceptionistCommandsBase
{
    [Fact]
    public void AddVisitorCommand_FailIfTheSameEntityExists()
    {
        //Arrange
        _mockVisitorRepo.Setup(repo => repo.GetVisitorByIdAsync(EXISTING_GUID)).Returns(GetExistingUserAsync());
        var command = new AddVisitorCommand(_mockVisitorRepo.Object);

        //Act

        //Assert
        Assert.ThrowsAsync<SameEntityExistsException>(() => command.ExecuteAsync(ExistingVisitor));
    }

    [Fact]
    public void AddVisitorCommand_FailIfVisitorWithTheSameEmailExists()
    {
        //Arrange
        _mockVisitorRepo.Setup(repo => repo.GetVisitorByEmailAsync(EXISTING_EMAIL)).Returns(GetUserWithExistingEmailAsync());
        var command = new AddVisitorCommand(_mockVisitorRepo.Object);

        //Act

        //Assert
        Assert.ThrowsAsync<SameEntityExistsException>(() => command.ExecuteAsync(VisitorWithExistingEmail));
    }

    [Fact]
    public void AddVisitorCommand_FailIfNameIsEmpty()
    {
        //Arrange
        _mockVisitorRepo.Setup(repo => repo.GetVisitorByIdAsync(EXISTING_GUID)).Returns(ReturnNull());
        var command = new AddVisitorCommand(_mockVisitorRepo.Object);

        //Act

        //Assert
        Assert.ThrowsAsync<RequiredPropertiesNotFilledException>(() => command.ExecuteAsync(VisitorWithEmptyName));
    }

	private Task<Visitor?> ReturnNull()
	{
        return Task.FromResult<Visitor?>(null);
    }

	private Task<Visitor?> GetExistingUserAsync()
	{
		return Task.FromResult<Visitor?>(ExistingVisitor);
	}

    private Task<Visitor?> GetUserWithExistingEmailAsync()
    {
        return Task.FromResult<Visitor?>(VisitorWithExistingEmail);
    }
}