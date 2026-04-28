using System.Collections;
using System.Reflection;

namespace TravelAgency.Common;

public class CrudServiceAsync<T> : ICrudServiceAsync<T>
{
    private readonly List<T> _items = new();
    private readonly object _lock = new();

    public async Task<bool> CreateAsync(T element)
    {
        return await Task.Run(() =>
        {
            lock (_lock)
            {
                _items.Add(element);
                return true;
            }
        });
    }

    public async Task<T> ReadAsync(Guid id)
    {
        return await Task.Run(() =>
        {
            lock (_lock)
            {
                return _items.FirstOrDefault(x => GetId(x) == id);
            }
        });
    }

    public async Task<IEnumerable<T>> ReadAllAsync()
    {
        return await Task.Run(() =>
        {
            lock (_lock)
            {
                return _items.ToList();
            }
        });
    }

    public async Task<IEnumerable<T>> ReadAllAsync(int page, int amount)
    {
        return await Task.Run(() =>
        {
            lock (_lock)
            {
                return _items.Skip(page * amount).Take(amount).ToList();
            }
        });
    }

    public async Task<bool> UpdateAsync(T element)
    {
        return await Task.Run(() =>
        {
            lock (_lock)
            {
                var id = GetId(element);
                var old = _items.FirstOrDefault(x => GetId(x) == id);

                if (old != null)
                {
                    _items.Remove(old);
                    _items.Add(element);
                    return true;
                }

                return false;
            }
        });
    }

    public async Task<bool> RemoveAsync(T element)
    {
        return await Task.Run(() =>
        {
            lock (_lock)
            {
                return _items.Remove(element);
            }
        });
    }

    public async Task<bool> SaveAsync()
    {
        return await Task.Run(() =>
        {
            lock (_lock)
            {
                // імітація збереження
                return true;
            }
        });
    }

    private Guid GetId(T element)
    {
        PropertyInfo property = typeof(T).GetProperty("Id");
        return (Guid)property.GetValue(element);
    }

    public IEnumerator<T> GetEnumerator()
    {
        return _items.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}