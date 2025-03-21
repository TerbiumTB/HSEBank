using Finances.Accounts;
using Finances.Categories;
using Finances.Operations;

namespace Finances.Commands;

public class AddOperationCommand : ICommand
{
    private IIndexedStorage<Operation> Operations { get; }
    private IIndexedStorage<BankAccount> Accounts { get; }
    private IIndexedStorage<Category> Categories { get; }

    // private FinanceFacade Storage { get; }
    private Guid AccountId { get; }
    private Guid CategoryId { get; }
    private int Amount { get; }
    private DateTime Date { get; }
    private string? Description { get; }


    public AddOperationCommand(IIndexedStorage<Operation> operations, IIndexedStorage<BankAccount> accounts, IIndexedStorage<Category> categories, Guid accountId, Guid categoryId, int amount,
        DateTime date,
        string? description)
    {
        Operations = operations;
        Accounts = accounts;
        Categories = categories;
        AccountId = accountId;
        CategoryId = categoryId;
        Amount = amount;
        Date = date;
        Description = description;
    }

    public void Execute()
    {
        var operation = OperationFactory.CreateOperation(AccountId, CategoryId, Amount, Date, Description);
        if (operation is null)
        {
            Console.WriteLine("Invalid operation");
            return;
        }

        Operations.Insert(operation);
        var account = Accounts.Find(AccountId)!;
        var category = Categories.Find(CategoryId)!;
        if (category.Type == CategoryType.Expense)
        {
            account.Debit(Amount);
        }
        else if (category.Type == CategoryType.Income)
        {
            account.Credit(Amount);
        }

        ;
        // Storage.Insert(OperationFactory.CreateOperation(AccountId, CategoryId, Amount, Date, Description)); 
    }
}