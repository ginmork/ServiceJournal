using System.Xml.Serialization;
using ServiceJournal.Logic;

namespace ServiceJournal.Data;

public class XmlRepairRepository : IRepairRepository
{
    private readonly string _path;
    private readonly XmlSerializer _serializer = new(typeof(List<Repair>));

    public XmlRepairRepository(string path)
    {
        _path = path;
    }

    public List<Repair> GetAll()
    {
        if (!File.Exists(_path))
        {
            return new List<Repair>();
        }

        using var reader = new StreamReader(_path);
        return _serializer.Deserialize(reader) as List<Repair> 
            ?? new List<Repair>();
    }

    public void Add(Repair item)
    {
        List<Repair> items = GetAll();
        items.Add(item);

        using var writer = new StreamWriter(_path);
        _serializer.Serialize(writer, items);
    }
}