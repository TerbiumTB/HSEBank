namespace Finances.Operations;
using Finances.Categories;
public class OperationCategoryValidator: IOperationValidator
{
    private IIndexedStorage<Category> Categories { get; }
    public IOperationValidator? Next { get; set; }
    
    public OperationCategoryValidator(IIndexedStorage<Category> categories)
    {
        Categories = categories;
    }
    
    public bool Validate(Operation operation)
    {
        if (Categories.Find(operation.CategoryId) is null)
        {
            return false;
        }
        
        return Next?.Validate(operation) ?? true;
    }
}