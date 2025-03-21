namespace Finances;

public interface IIndexedStorage<T>: IEnumerable<T> where T: IModel
{
    public IReadOnlyDictionary<Guid, T> Read();
    public void Insert(T item);
    public void Remove(Guid id);
    public T? Find(Guid id);
    
}
