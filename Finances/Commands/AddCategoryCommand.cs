namespace Finances.Commands;
using Finances.Categories;

public class AddCategoryCommand :ICommand
{
    private IIndexedStorage<Category> Storage { get; }
    
    // private Category Category { get; }
    private CategoryType Type { get; }
    private string Name { get; }
    

    public AddCategoryCommand(IIndexedStorage<Category> storage, CategoryType type, string name)
    {
        Storage = storage;
        // Category = category;
        Type = type;
        Name = name;
    }
    

    public void Execute()
    {
        Storage.Insert(CategoryFactory.CreateCategory(Type, Name));
    }
}