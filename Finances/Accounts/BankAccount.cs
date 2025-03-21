using Finances.Export;

namespace Finances.Accounts;
using Finances.Format;
public class BankAccount : IModel
{
    public Guid Id { get; }
    public string Name { get; internal set; }
    public int Balance { get; private set; }

    public void Debit(int amount)
    {
        if (Balance - amount < 0)
        {
            Console.WriteLine("Negative balance! Not enough money!");
        }
        Balance -= amount;
    }
    public void Credit(int amount)
    {
        Balance += amount;
    }
    public BankAccount(Guid id, string name, int balance)
    {
        Id = id;
        Name = name;
        Balance = balance;
    }

    public override string ToString()
    {
        return $"\"{Id}\" \t Name: {Name}\t Balance: {Balance}";
    }

    public string OnFormat(IFormatter formatter)
    {
        return formatter.Format(this);
    }
    // public static class BankAccountFactory
    // {
    //     public static BankAccount
    // }
}