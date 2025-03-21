using Finances.Categories;
using Finances.Operations;

namespace Finances.Commands;

using Accounts;
using Operations;

public class ShowAccountsCommand : ICommand
{
    private IEnumerable<BankAccount> Storage { get; set; }

    public ShowAccountsCommand(IEnumerable<BankAccount> storage)
    {
        Storage = storage;
    }

    public void Execute()
    {
        foreach (var item in Storage)
        {
            Console.WriteLine(item);
        }
    }
}

public class ShowCategoriesCommand : ICommand
{
    private IEnumerable<Category> Storage { get; set; }

    public ShowCategoriesCommand(IEnumerable<Category> storage)
    {
        Storage = storage;
    }

    public void Execute()
    {
        foreach (var item in Storage)
        {
            Console.WriteLine(item);
        }
    }
}

public class ShowOperationsCommand : ICommand
{
    private IEnumerable<Operation> Storage { get; set; }

    public ShowOperationsCommand(IEnumerable<Operation> storage)
    {
        Storage = storage;
    }

    public void Execute()
    {
        foreach (var item in Storage)
        {
            Console.WriteLine(item);
        }
    }
}