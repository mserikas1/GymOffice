namespace GymOffice.Business.Common.Exceptions;
public class SameEntityExistsException : Exception
{
<<<<<<< HEAD
	public SameEntityExistsException(string name, object key)
		: base($"Entity \"{name}\" with the same property ({key}) already exists")
    {

	}
=======
    public SameEntityExistsException(string name, object key)
        : base($"Entity \"{name}\" with the same property ({key}) already exists")
    {

    }
>>>>>>> oleg-feature-receptionist-pages
}
