using System.Text;
using System.Text.Json;
// using Finances.Export;
namespace Finances.Format;

public abstract class StorageFormatter : IStorageFormatter
{
    protected readonly StringBuilder _stringBuilder = new();
    protected IFormatter Formatter { get;  init; }


    protected abstract void Begin();
    protected abstract void End();
    protected abstract void Sep();


    public string Format<T>(IEnumerable<T> storage) where T : class, IOnFormat
    {
        // formatter
        Begin();
        // _stringBuilder.Append('[');
        foreach (var item in storage)
        {
            _stringBuilder.Append(item.OnFormat(Formatter));
            // _stringBuilder.Append(',');
            
            Sep();
        }
        
        End();
        // _stringBuilder.Append(']');

        return _stringBuilder.ToString();
        // return JsonSerializer.Serialize(storage);
    }
}

