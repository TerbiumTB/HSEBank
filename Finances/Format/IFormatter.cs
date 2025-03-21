namespace Finances.Format;

using Operations;
using Accounts;
using Finances.Categories;

public interface IFormatter
{
    public string Format(BankAccount account);
    public string Format(Category category);
    public string Format(Operation operation);
}