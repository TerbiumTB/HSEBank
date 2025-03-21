namespace Finances.Format;

public interface IStorageFormatter
{
    public string Format<T>(IEnumerable<T> storage) where T : class, IOnFormat;
    // public 
}