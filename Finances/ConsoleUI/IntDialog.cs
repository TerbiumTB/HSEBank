namespace Finances.ConsoleUI;

public class IntDialog : IDialog<int>
{
    public void Show(string msg)
    {
        Console.Write(msg);
    }

    public int Scan()
    {
        string? input = Console.ReadLine();
        int output;
        // int.TryParse(input, out int output);
        while(!int.TryParse(input, out output)){
            Console.Write("Enter decimal number: ");
            input = Console.ReadLine();
        } 
        return output;
    }
}