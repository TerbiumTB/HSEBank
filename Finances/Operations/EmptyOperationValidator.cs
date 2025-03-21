namespace Finances.Operations;

public class OperationValidator : IOperationValidator
{
    public IOperationValidator? Next { get; set; }

    public bool Validate(Operation operation)
    {
        return Next?.Validate(operation) ?? true;
    }
}