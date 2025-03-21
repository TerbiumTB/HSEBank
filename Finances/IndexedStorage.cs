using System.Collections;
using Finances.Export;
using System.ComponentModel.Design;
using System.Reflection;
using System;
using System.Text;
using Finances.Accounts;

namespace Finances;

public class IndexedStorage<T> : IIndexedStorage<T> where T: IModel
{
    private readonly Dictionary<Guid, T> _storage = new();
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    public IEnumerator<T> GetEnumerator()
    {
        return _storage.Values.GetEnumerator() ;
    }
    public IReadOnlyDictionary<Guid, T> Read()
    {
        return _storage;
    }

    public T? Find(Guid id)
    {   
        _storage.TryGetValue(id, out var result);
        return result;
    }

    public void Insert(T item)
    {
        _storage[item.Id] = item;
    }

    public void Remove(Guid id)
    {
        _storage.Remove(id);
    }

    public override string ToString()
    {
        StringBuilder s = new();
        foreach (var item in _storage.Values)
        {
            s.AppendLine(item.ToString());
        }

        return s.ToString();
    }
}