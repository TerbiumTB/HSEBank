using System.Text.RegularExpressions;

namespace Finances.ConsoleUI;

public class OptionDialog<T>: IDialog<T> where T: struct, Enum
{
    public void Show(string msg)
    {
        Console.WriteLine(msg);

        int i = 1;
        string opt;
        foreach (var t in Enum.GetValues(typeof(T)).Cast<T>())
        {
            opt = Regex.Replace(t.ToString(), @"([a-z])([A-Z])", "$1 $2");
            Console.WriteLine($"{i}. {opt}");
            ++i;
        }
        // for (var i = 0; i <  Options.Count; ++i)
        // {
        //     Console.WriteLine($"{i + 1}: {Options[i]}");
        // }
    }
    public  T Scan(){
        T option;
        Console.Write("Enter option: ");
        string? input = Console.ReadLine();      
        while(!Enum.TryParse(input, out option) || !Enum.IsDefined(option)){
            Console.Write("Invalid option. Enter correct option number: ");
            input = Console.ReadLine();
        } 
        return option;
    }
}