namespace Finances.ConsoleUI;

public class StringDialog : IDialog<string>
{
    public void Show(string msg)
    {
        Console.Write(msg);
    }

    public string Scan()
    {
        string? output = Console.ReadLine();
        while (output is null or "")
        {
            Console.Write("Enter not empty line:  ");
            output = Console.ReadLine();
        }

        return output;
    }
}