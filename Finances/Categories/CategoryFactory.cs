namespace Finances.Categories;

public static class CategoryFactory
{
    public static Category CreateCategory(CategoryType type, string name)
    {
        return new Category(Guid.NewGuid(), type, name);
    }
}