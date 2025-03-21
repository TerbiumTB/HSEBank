namespace Finances.ConsoleUI;

public interface IDialog
{
    public void Show(string msg);
    // public T Scan<T>();
    public T Scan<T>();
}

public interface IDialog<T>
{
    public void Show(string msg);
    // public T Scan<T>();
    public T Scan();
}
public interface IOptionDialog : IDialog
{
    public new T Scan<T>() where T: struct, Enum;
}

// public interface IIntDialog : IDialog
// {
//     public T Scan<T>();
// }