using Finances.Operations;

namespace Finances.Commands;

using Format;
using Export;


public class ExportOperationsStorageCommand: ICommand
{
    private IIndexedStorage<Operation> Storage { get; }
    private IStorageFormatter Fotmatter { get; }
    private TextWriter Writer { get; }
    
    public ExportOperationsStorageCommand(IIndexedStorage<Operation> storage, IStorageFormatter formatter, TextWriter writer){
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