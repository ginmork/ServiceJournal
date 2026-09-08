using ServiceJournal.Data;
using ServiceJournal.Logic;

IRepairRepository repository = new RepairRepository();

var service = new RepairService(repository);

Console.WriteLine("Незавершённые ремонты:");
foreach (var item in service.GetImportant())
{
    Console.WriteLine($"{item.Id}: {item.Equipment} - {item.IsDone}");
}