using Finances.Accounts;
using Finances.Categories;

namespace Finances.Format;
using Accounts;
// using Category;
using Operations;

public class CsvFormatter : IFormatter
{
    public string Format(BankAccount account)
    {
        return account.Id + "," + account.Name + "," + account.Balance + ";";
    }
    public string Format(Category category)
    {
        return category.Id + "," + category.Name + "," + category.Type + ";";
    }
    

    public string Format(Operation operation)
    {
        return operation.Id + "," + operation.BankAccountId + "," + operation.CategoryId + "," + operation.Amount + "," + operation.Date + "," + operation.Description + ";";
    }
}