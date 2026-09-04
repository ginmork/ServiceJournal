using ServiceJournal.Logic;

var service = new RepairService();
Console.WriteLine("Незавершённые ремонты:");
foreach (var item in service.GetUnfinished())
{
    Console.WriteLine($"{item.Id}: {item.Equipment} - {item.IsDone}");
}