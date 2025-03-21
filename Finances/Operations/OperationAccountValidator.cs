namespace Finances.Operations;
using Accounts;

public class OperationAccountValidator : IOperationValidator
{
    private IIndexedStorage<BankAccount> Accounts { get; }
    public IOperationValidator? Next { get; set; }

    public OperationAccountValidator(IIndexedStorage<BankAccount> accounts)
    {
        Accounts = accounts;
    }

    public bool Validate(Operation operation)
    {
        if (Accounts.Find(operation.BankAccountId) is null)
        {
            return false;
        }

        return Next?.Validate(operation) ?? true;
    }
}