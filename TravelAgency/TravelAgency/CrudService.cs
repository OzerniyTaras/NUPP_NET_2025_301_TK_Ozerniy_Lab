using System.Reflection;

namespace TravelAgency.Common;

public class CrudService<T> : ICrudService<T>
{
    private readonly List<T> _items = new();

    public void Create(T element)
    {
        _items.Add(element);
    }

    public T Read(Guid id)
    {
        return _items.FirstOrDefault(x => GetId(x) == id);
    }

    public IEnumerable<T> ReadAll()
    {
        return _items;
    }

    public void Update(T element)
    {
        var id = GetId(element);
        var oldElement = Read(id);

        if (oldElement != null)
        {
            Remove(oldElement);
            Create(element);
        }
    }

    public void Remove(T element)
    {
        _items.Remove(element);
    }

    private Guid GetId(T element)
    {
        PropertyInfo property = typeof(T).GetProperty("Id");
        return (Guid)property.GetValue(element);
    }
}