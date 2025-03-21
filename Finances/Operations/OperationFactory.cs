namespace Finances.Operations;

public static class OperationFactory
{
    public static IOperationValidator Validator { get; set; } = new OperationValidator();
    
    public static Operation? CreateOperation(Guid accountId, Guid categoryId, int amount, DateTime date, string? description)
    {
        var operation = new Operation(Guid.NewGuid(), accountId, categoryId, amount, date, description);
        return Validator.Validate(operation) ? operation : null;
    }
}