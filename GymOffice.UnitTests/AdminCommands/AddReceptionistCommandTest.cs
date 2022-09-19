namespace GymOffice.UnitTests.AdminCommands;
public class AddReceptionistCommandTests : TestAdminCommandsBase
{
	[Fact]
	public void AddReceptionistCommand_FailIfTheSameEntityExists()
	{
		//Arrange
		_mockEmployeeRepo.Setup(repo => repo.GetReceptionistByIdAsync(EXISTING_GUID)).Returns(GetExistingUserAsync());
		var _sut = new AddReceptionistCommand(_mockEmployeeRepo.Object);

		//Act

		//Assert
		Assert.ThrowsAsync<SameEntityExistsException>(() => _sut.ExecuteAsync(ExistingReceptionist));
	}

    [Fact]
    public void AddReceptionistCommand_FailIfNameIsEmpty()
    {
        //Arrange
        _mockEmployeeRepo.Setup(repo => repo.GetReceptionistByIdAsync(EXISTING_GUID)).Returns(ReturnNull());
        var _sut = new AddReceptionistCommand(_mockEmployeeRepo.Object);

        //Act

        //Assert
        Assert.ThrowsAsync<RequiredPropertiesNotFilledException>(() => _sut.ExecuteAsync(ReceptionistWithEmptyName));
    }

	private Task<Receptionist?> ReturnNull()
	{
        return Task.FromResult<Receptionist?>(null);
    }

	private Task<Receptionist?> GetExistingUserAsync()
	{
		return Task.FromResult<Receptionist?>(ExistingReceptionist);
	}
}