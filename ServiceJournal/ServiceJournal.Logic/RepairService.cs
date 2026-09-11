namespace ServiceJournal.Logic;

public class RepairService
{
    private readonly IRepairRepository _repository;

    public RepairService(IRepairRepository repository)
    {
        _repository = repository;
    }

    public List<Repair> GetImportant()
    {
        return _repository.GetAll()
            .Where(item => item.IsDone == "Нет")
            .ToList();
    }

    public int GetCount()
    {
        return GetImportant().Count;
    }

    public void AddRepair(string equipment, string isDone)
    {
        if (string.IsNullOrWhiteSpace(equipment))
            return;

        int nextId = _repository.GetAll().Count + 1;
        _repository.Add(new Repair
        {
            Id = nextId,
            Equipment = equipment,
            IsDone = isDone
        });
    }
}