using System.Text.Json;
using Finances.Operations;
using Finances.Categories;
using Finances.Accounts;

namespace Finances.Format;


public class JsonFormatter: IFormatter
{
    public string Format(BankAccount account)
    {
        return JsonSerializer.Serialize(account);
    }
    public string Format(Category category)
    {
        return JsonSerializer.Serialize(category);
    }
    

    public string Format(Operation operation)
    {
        return JsonSerializer.Serialize(operation);
    }
}