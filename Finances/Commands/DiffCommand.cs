namespace Finances.Commands;
using Analytics;
using Operations;
using Categories;
public class DiffCommand : ICommand
{
    private DateTime Start { get; }
    private DateTime End { get; }
    private Guid AccountId { get; }
    private IIndexedStorage<Operation> OperationsStorage { get; }
    private IIndexedStorage<Category> CategoryStorage { get; }
    
    public DiffCommand(DateTime start, DateTime end, Guid accountId, 
        IIndexedStorage<Operation> operationsStorage, IIndexedStorage<Category> categoryStorage)
    {
        Start = start;
        End = end;
        AccountId = accountId;
        OperationsStorage = operationsStorage;
        CategoryStorage = categoryStorage;
    }
    
    public void Execute()
    {
        var analyzer = new OperationAnalytics(OperationsStorage, CategoryStorage);

        Console.WriteLine($"Balance in given period: {analyzer.Diff(AccountId, Start, End)}");
    }
}