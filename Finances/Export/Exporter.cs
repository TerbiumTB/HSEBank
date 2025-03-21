using Finances.Format;

namespace Finances.Export;

public class Exporter : IExporter
{
    private IFormatter Formatter { get; set; }
    private IOnFormat Item { get; set; }
    public Exporter(IOnFormat item, IFormatter formatter){
        Formatter = formatter;
        Item = item;
    }
    public void Export(TextWriter writer){
        writer.Write(Item.OnFormat(Formatter));
    }
}