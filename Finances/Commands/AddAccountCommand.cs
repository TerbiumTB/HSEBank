namespace Finances.Commands;
using Finances.Accounts;
public class AddAccountCommand : ICommand
{
    private IIndexedStorage<BankAccount> Storage { get; }
    private string Name { get; }
    private int Balance { get; }
    public AddAccountCommand(IIndexedStorage<BankAccount> storage, string name, int balance)
    {
        Storage = storage;
        Name = name;
        Balance = balance;
    }
    public void Execute()
    {
        Storage.Insert(BankAccountFactory.CreateAccount(Name, Balance));
    }
}

