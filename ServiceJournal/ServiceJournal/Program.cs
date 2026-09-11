using ServiceJournal.Data;
using ServiceJournal.Logic;

string jsonPath = Path.Combine(AppContext.BaseDirectory, "repairs.json");
string xmlPath  = Path.Combine(AppContext.BaseDirectory, "repairs.xml");

string kind = args.Length > 0 ? args[0] : "json";

IRepairRepository repository = kind switch
{
    "xml"    => new XmlRepairRepository(xmlPath),
    "memory" => new RepairRepository(),
    "demo"   => new DemoRepairRepository(),
    _        => new JsonRepairRepository(jsonPath)
};

Console.WriteLine($"Хранилище: {kind}");

var service = new RepairService(repository);

Console.Write("Название оборудования: ");
string equipment = Console.ReadLine() ?? "";

service.AddRepair(equipment, "Нет");

Console.WriteLine("Отобранные записи:");
foreach (var item in service.GetImportant())
{
    Console.WriteLine($"{item.Id}: {item.Equipment} - {item.IsDone}");
}

Console.WriteLine($"Незавершённых ремонтов: {service.GetCount()}");