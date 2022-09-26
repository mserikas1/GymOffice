namespace GymOffice.Business.Common.Exceptions;
public class CannotAddVisitorToTrainingException : Exception
{
	public CannotAddVisitorToTrainingException(string trainingName)
		: base($"Cannot add the visitor to training \"{trainingName}\" because the training list is full")
	{

	}
}
