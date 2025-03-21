namespace Finances.ConsoleUI;

public class GuidDialog : IDialog<Guid>
{
    public void Show(string msg)
    {
        Console.Write(msg);
    }

    public Guid Scan()
    {
        string? input = Console.ReadLine();
        Guid output;
        while(!Guid.TryParse(input, out output)){
            Console.Write("Enter valid ID: ");
            input = Console.ReadLine();
        }
        return output;
    }
}