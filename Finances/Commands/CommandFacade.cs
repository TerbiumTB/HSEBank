namespace Finances.Commands;

public class CommandQueue
{
    Queue<ICommand> _commands = new Queue<ICommand>();

    public void Add(ICommand command)
    {
        command = new TimingDecorator(command);
        _commands.Enqueue(command);
    }

    public void ExecuteFirst()
    {
        if (!IsEmpty)
        {
            _commands.Dequeue().Execute();
        }
    }

    public void ExecuteAll()
    {
        while (!IsEmpty)
        {
            ExecuteFirst();
        }
    }

    public bool IsEmpty => _commands.Count == 0;
}