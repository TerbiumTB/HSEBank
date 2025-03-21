namespace Finances.Format;

public class CsvStorageFormatter : StorageFormatter
{
    public CsvStorageFormatter()
    {
        Formatter = new CsvFormatter();
    }

    protected override void Begin(){}
    protected override void End(){}

    protected override void Sep()
    {
        _stringBuilder.Append("\n");
    }
}