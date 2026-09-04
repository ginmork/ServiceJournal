using ServiceJournal.Data;

namespace ServiceJournal.Logic;

public class RepairService
{
    private readonly RepairRepository _repository = new();

    public List<Repair> GetUnfinished()
    {
        return _repository.GetAll()
            .Where(item => item.IsDone == "Нет")
            .ToList();
    }
}