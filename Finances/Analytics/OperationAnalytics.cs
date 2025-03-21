using System.ComponentModel;
using Finances.Operations;
using Finances.Categories;

namespace Finances.Analytics;

public class OperationAnalytics
{
    private IIndexedStorage<Operation> Operations { get; set; }
    private IIndexedStorage<Category> Categories { get; set; }

    public OperationAnalytics(IIndexedStorage<Operation> operations, IIndexedStorage<Category> categories)
    {
        Operations = operations;
        Categories = categories;
    }

    public int Diff(Guid accountId, DateTime start, DateTime end)
    {
        var select = Operations.Where(op => op.BankAccountId == accountId && op.Date >= start && op.Date <= end);
        int sum = 0;
        foreach (var op in select)
        {
            var cat = Categories.Find(op.CategoryId);
            if (cat is null)
            {
                // throw new WarningException("Category not found");
                continue;
            }

            if (cat.Type == CategoryType.Income)
            {
                sum += op.Amount;
            }
            else
            {
                sum -= op.Amount;
            }
        }

        return sum;
    }

    public IReadOnlyDictionary<string, IndexedStorage<Operation>> GroupByCat(Guid accountId)
    {
        var groups = new Dictionary<string, IndexedStorage<Operation>>();
        // var acc = Accounts.Find(accountId);
        // if (acc is null)
        // {
        //     return groups;
        // }

        var select = Operations.Where(op => op.BankAccountId == accountId);
        foreach (var item in select)
        {
            var cat = Categories.Find(item.CategoryId);

            if (cat?.Name is null)
            {
                continue;
            }
            
            if (!groups.ContainsKey(cat.Name))
            {
                groups[cat.Name] = new();
            }

            groups[cat.Name].Insert(item);
        }

        return groups;
    }
}