using Finances.Categories;

namespace Finances.Commands;
using Analytics;
using Operations;
using Categories;
public class GroupByCatCommand : ICommand
{
        private Guid AccountId { get; }
        // private CategoryType Type { get; }
        private IIndexedStorage<Category> CategoryStorage { get; }
        private IIndexedStorage<Operation> OperationsStorage { get; }
        
        public GroupByCatCommand(Guid accountId,
            IIndexedStorage<Operation> operationsStorage, IIndexedStorage<Category> categoryStorage)
        {
            AccountId = accountId;
            // Type = type;
            OperationsStorage = operationsStorage;
            CategoryStorage = categoryStorage;
        }
        
        public void Execute()
        {
            var analyzer = new OperationAnalytics(OperationsStorage, CategoryStorage);
            foreach (var item in analyzer.GroupByCat(AccountId))
            {
                Console.WriteLine($"Category: {item.Key}");
                foreach (var op in item.Value)
                {
                    Console.WriteLine(op);
                }
            }
        }
}