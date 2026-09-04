namespace ServiceJournal.Data;

public class RepairRepository
{
    private readonly List<Repair> _items = new()
    {
        new Repair { Id = 1, Equipment = "Принтер HP LaserJet", IsDone = "Нет" },
        new Repair { Id = 2, Equipment = "Компьютер Dell", IsDone = "Да" },
        new Repair { Id = 3, Equipment = "Монитор Samsung", IsDone = "Нет" },
        new Repair { Id = 4, Equipment = "Клавиатура Logitech", IsDone = "Да" }
    };

    public List<Repair> GetAll()
    {
        return _items;
    }
}