using Finances.Operations;

namespace Finances.Commands;

public class AddOperationCommand : ICommand
{
    private IIndexedStorage<Operation> Storage { get; }
    // private FinanceFacade Storage { get; }
    private Guid AccountId { get; }
    private Guid CategoryId { get; }
    private int Amount { get; }
    private DateTime Date { get; }
    private string? Description { get; }


    public AddOperationCommand(IIndexedStorage<Operation> storage, Guid accountId, Guid categoryId, int amount, DateTime date,
        string? description)
    {
        Storage = storage;
        AccountId = accountId;
        CategoryId = categoryId;
        Amount = amount;
        Date = date;
        Description = description;
    }

    public void Execute()
    {
        var operation = OperationFactory.CreateOperation(AccountId, CategoryId, Amount, Date, Description);
        if (operation != null)
        {
            Storage.Insert(operation);
        }
        Console.WriteLine("Invalid operation");
        // Storage.Insert(OperationFactory.CreateOperation(AccountId, CategoryId, Amount, Date, Description)); 
    }
}