namespace Finances.Export;

public interface IExporter
{
    public void Export(TextWriter writer);
}