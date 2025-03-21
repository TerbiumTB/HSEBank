namespace Finances.Commands;
using System.Diagnostics;

public class TimingDecorator : ICommand
{
    private readonly ICommand _command;

    public TimingDecorator(ICommand command)
    {
        _command = command;
    }

    public void Execute()
    {
        Stopwatch stopwatch = Stopwatch.StartNew();
        _command.Execute();
        stopwatch.Stop();
        Console.WriteLine($"Execution time: {stopwatch.ElapsedMilliseconds} ms");
    }
}