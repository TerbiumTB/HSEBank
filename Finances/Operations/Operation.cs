using Finances.Export;
using Finances.Format;

namespace Finances.Operations;



public class Operation : IModel
{
    public Guid Id { get; }
    public Guid BankAccountId { get;  }
    public Guid CategoryId { get;  }
    public int Amount { get; }
    public DateTime Date { get; }
    public string? Description { get; set; }

    public Operation()
    {
        
    }
    public Operation(Guid id, Guid bankAccountId, Guid categoryId, int amount, DateTime date, string? description)
    {
        Id = id;
        BankAccountId = bankAccountId;
        CategoryId = categoryId;
        Amount = amount;
        Date = date;
        Description = description;
    }
    public string OnFormat(IFormatter formatter)
    {
        return formatter.Format(this);
    }
    
    public override string ToString()
    {
        return Id + "\tBankAccountId: " + BankAccountId + "\tCategoryId: " + CategoryId + "\tAmount: " + Amount + "\tDate: " + Date + "\tDescription: " + Description;
    }
}