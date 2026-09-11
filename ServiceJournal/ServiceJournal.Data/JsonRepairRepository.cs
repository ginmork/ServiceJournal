using System.Text.Json;
using System.Text.Encodings.Web;
using ServiceJournal.Logic;

namespace ServiceJournal.Data;

public class JsonRepairRepository : IRepairRepository
{
    private readonly string _path;
    private readonly JsonSerializerOptions _options = new()
    {
        WriteIndented = true,
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
    };

    public JsonRepairRepository(string path)
    {
        _path = path;
    }

    public List<Repair> GetAll()
    {
        if (!File.Exists(_path))
        {
            return new List<Repair>();
        }

        string text = File.ReadAllText(_path);

        try
        {
            return JsonSerializer.Deserialize<List<Repair>>(text) 
                ?? new List<Repair>();
        }
        catch (JsonException)
        {
            return new List<Repair>();
        }
    }

    public void Add(Repair item)
    {
        List<Repair> items = GetAll();
        items.Add(item);
        string text = JsonSerializer.Serialize(items, _options);
        File.WriteAllText(_path, text);
    }
}