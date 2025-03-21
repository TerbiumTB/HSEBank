namespace Finances.ConsoleUI;
public class DateDialog : IDialog<DateTime>
{
    public void Show(string msg)
    {
        Console.Write(msg);
    }
    public DateTime Scan()
    {
        string? input = Console.ReadLine();
        DateTime output;
        while(!DateTime.TryParse(input, out output)){
            Console.Write("Enter valid date: ");
            input = Console.ReadLine();
        }
        return output;
    }
}