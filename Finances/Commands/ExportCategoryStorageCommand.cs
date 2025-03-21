using Finances.Categories;
using Finances.Format;

namespace Finances.Commands;
using Finances.Export;
public class ExportCategoryStorageCommand: ICommand
{
    private IIndexedStorage<Category> Storage { get; }
    private IStorageFormatter Fotmatter { get; }
    private TextWriter Writer { get; }
    
    public ExportCategoryStorageCommand(IIndexedStorage<Category> storage, IStorageFormatter formatter, TextWriter writer){
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