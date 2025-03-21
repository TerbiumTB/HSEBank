namespace Finances.Format;

public class JsonStorageFormatter : StorageFormatter
{
    public JsonStorageFormatter()
    {
        Formatter = new JsonFormatter();
    }
    protected override void Begin()
    {
        _stringBuilder.Append("[\n");
    }
    protected override void Sep()
    {
        _stringBuilder.Append(",\n");
    }

    protected override void End()
    {
        _stringBuilder.Append(']');
    }
}