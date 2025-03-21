using Finances.Accounts;

namespace Finances.Commands;
using Finances.Format;
using Finances.Export;
using Accounts;

public class ExportAccountStorageCommand: ICommand
{
    private IIndexedStorage<BankAccount> Item { get;  }
    private IStorageFormatter Fotmatter { get; }
    private TextWriter Writer { get; }
    
    public ExportAccountStorageCommand(IIndexedStorage<BankAccount> item, IStorageFormatter formatter, TextWriter writer){
        Item = item;
        Fotmatter = formatter;
        Writer = writer;
    }

    public void Execute()
    {
        var exporter = new StorageExporter(Item, Fotmatter);
        exporter.Export(Writer);
        Writer.Close();
    }
}