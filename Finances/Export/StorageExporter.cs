namespace Finances.Export;
using Finances.Format;

public class StorageExporter : IExporter
{
    private IStorageFormatter Formatter { get; set; }
    private IEnumerable<IOnFormat> Storage { get; set; }
    public StorageExporter(IEnumerable<IOnFormat> storage, IStorageFormatter formatter){
        Formatter = formatter;
        Storage = storage;
    }
    public void Export(TextWriter writer){
        writer.Write(Formatter.Format(Storage));
    }
}
