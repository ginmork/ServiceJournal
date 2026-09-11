namespace ServiceJournal.Logic;
public interface IRepairRepository
{
List<Repair> GetAll();
void Add(Repair item);  
}
