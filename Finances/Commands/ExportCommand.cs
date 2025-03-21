using Finances.Format;
using Finances.Export;
namespace Finances.Commands;

public class ExportCommand : ICommand
{
    private IOnFormat Item { get;  }
    private IFormatter Fotmatter { get; }
    private TextWriter Writer { get; }
    
    public ExportCommand(IOnFormat item, IFormatter formatter, TextWriter writer){
        Item = item;
        Fotmatter = formatter;
        Writer = writer;
    }

    public void Execute()
    {
        var exporter = new Exporter(Item, Fotmatter);
        exporter.Export(Writer);
        // exporter.Export(item.OnFormat(formatter)));;
    }
}