namespace Finances.Operations;

public interface IOperationValidator
{
    IOperationValidator? Next { get; set; }
    public bool Validate(Operation operation);
}