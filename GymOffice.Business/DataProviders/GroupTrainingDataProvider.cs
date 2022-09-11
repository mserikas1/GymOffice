namespace GymOffice.Business.DataProviders;
public class GroupTrainingDataProvider : IGroupTrainingDataProvider
{
    private readonly IGroupTrainingRepository _trainingRepository;

    public GroupTrainingDataProvider(IGroupTrainingRepository trainingRepository)
    {
        _trainingRepository = trainingRepository;
    }

    public async Task<IEnumerable<Training>?> GetAllTrainingsAsync()
    {
        return await _trainingRepository.GetAllAsync();
    }

    public async Task<Training?> GetTrainingByIdAsync(Guid id)
    {
        Training? training = await _trainingRepository.GetByIdAsync(id);

        if (training == null)
        {
            throw new NotFoundException(nameof(Training), id);
        }

        return training;
    }

    public async Task<IEnumerable<Training>?> GetTrainingsByCoachAsync(Guid coachId)
    {
        return await _trainingRepository.GetTrainingsByCoachAsync(coachId);
    }

    public async Task<IEnumerable<Training>?> GetTrainingsByDateAsync(DateOnly date)
    {
        return await _trainingRepository.GetTrainingsByDateAsync(date);
    }

    public async Task<IEnumerable<Training>?> GetTrainingsByDateIntervalAsync(DateOnly startDate, DateOnly endDate)
    {
        return await _trainingRepository.GetTrainingsByDateIntervalAsync(startDate, endDate);
    }

    public async Task<IEnumerable<Training>?> GetTrainingsByNameAsync(string name)
    {
        return await _trainingRepository.GetTrainingsByNameAsync(name);
    }

    public async Task<IEnumerable<Training>?> GetTrainingsByTimeIntervalAsync(TimeOnly startTime, TimeOnly endTime)
    {
        return await _trainingRepository.GetTrainingsByTimeIntervalAsync(startTime, endTime);
    }
}
