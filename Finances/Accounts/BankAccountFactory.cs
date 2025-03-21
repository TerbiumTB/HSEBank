namespace Finances.Accounts;

public static class BankAccountFactory
{
    public static BankAccount CreateAccount(string name, int balance)
    {
        return new BankAccount(Guid.NewGuid(), name, balance);
    }
}
