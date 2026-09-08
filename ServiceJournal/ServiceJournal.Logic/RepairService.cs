namespace ServiceJournal.Logic;

public class RepairService
{
    private readonly IRepairRepository _repository;

    public RepairService (IRepairRepository repository) {
		_repository = repository;
	}
	
	public List<Repair> GetImportant()
    {
        return _repository.GetAll()
            .Where(item => item.IsDone == "Нет")
            .ToList();
    }
}