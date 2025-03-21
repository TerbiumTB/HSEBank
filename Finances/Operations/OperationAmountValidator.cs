namespace Finances.Operations;

public class OperationAmountValidator: IOperationValidator
{
    public IOperationValidator? Next { get; set; }
    
    public bool Validate(Operation operation)
    {
        if (operation.Amount <= 0)
        {
            return false;
        }
        
        return Next?.Validate(operation) ?? true;
    }
}