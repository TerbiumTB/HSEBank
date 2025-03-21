using Finances.Export;
using Finances.Format;

namespace Finances.Categories;


public enum CategoryType
{
    Income = 1,
    Expense
}

public class Category : IModel
{
    public Guid Id { get; }
    public CategoryType Type { get; }
    public string? Name { get; set; }

    public Category(Guid id, CategoryType type, string name)
    {
        Id = id;
        Type = type;
        Name = name;
    }
    public string OnFormat(IFormatter formatter)
    {
        return formatter.Format(this);
    }
    
    public override string ToString()
    {
        return Id + "\tName: " + Name + "\tType: " + Type;
    }
}