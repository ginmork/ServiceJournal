using ServiceJournal.Logic;

namespace ServiceJournal.Data;

public class DemoRepairRepository : IRepairRepository
{
    public List<Repair> GetAll()
    {
        return new List<Repair>
        {
            new Repair 
            { 
                Id = 100, 
                Equipment = "Монитор Samsung", 
                IsDone = "Нет"                 
            }
        };
    }
}