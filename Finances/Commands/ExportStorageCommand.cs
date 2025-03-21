namespace Finances.Commands;

using Operations;
using Format;
using Export;

public class ExportStorageCommand : ICommand
{
    private IIndexedStorage<IModel> Storage { get; }
    private IStorageFormatter Fotmatter { get; }
    private TextWriter Writer { get; }
    
    public ExportStorageCommand(IIndexedStorage<IModel> storage, IStorageFormatter formatter, TextWriter writer){
        Storage = storage;
        Fotmatter = formatter;
        Writer = writer;
    }

    public void Execute()
    {
        var exporter = new StorageExporter(Storage, Fotmatter);
        exporter.Export(Writer);
        // exporter.Export(item.OnFormat(formatter)));;
    }
}