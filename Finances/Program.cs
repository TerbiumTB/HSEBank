// See https://aka.ms/new-console-template for more information

using System.ComponentModel.Design;
using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;

namespace Finances;

using Finances.Format;
using Finances.Operations;
using Finances.Accounts;
using Finances.Export;
using Finances.Commands;
using Finances.ConsoleUI;
using Finances.Categories;


public enum Validation
{
    Default,
    Account,
    Category,
    Amount
}
public enum CommandType
{
    AddBankAccount = 1,
    AddCategory,
    MakeOperation,
    Show,
    Export,
    Analitics,
    Quit
}

public enum Answer
{
    Yes = 1,
    No
}

public enum Model
{
    Account = 1,
    Category,
    Operation
}

public enum AnalitcsType
{
    AccountExpence = 1,
    GroupByCategory,
}

public enum FileFormat
{
    Json = 1,
    Csv
}

class Program
{
    static void Main()
    {
        var services = new ServiceCollection();

        services.AddKeyedSingleton<IOperationValidator, OperationValidator>(Validation.Default);
        services.AddKeyedSingleton<IOperationValidator, OperationAccountValidator>(Validation.Account);
        services.AddKeyedSingleton<IOperationValidator, OperationCategoryValidator>(Validation.Category);
        services.AddKeyedSingleton<IOperationValidator, OperationAmountValidator>(Validation.Amount);
        
        services.AddSingleton<IIndexedStorage<BankAccount>, IndexedStorage<BankAccount>>();
        services.AddSingleton<IIndexedStorage<Category>, IndexedStorage<Category>>();
        services.AddSingleton<IIndexedStorage<Operation>, IndexedStorage<Operation>>();
        
        var serviceProvider = services.BuildServiceProvider();
        
        
        var accounts = serviceProvider.GetService<IIndexedStorage<BankAccount>>()!;
        var categories = serviceProvider.GetService<IIndexedStorage<Category>>()!;
        var operations = serviceProvider.GetService<IIndexedStorage<Operation>>()!;

        accounts.Insert(BankAccountFactory.CreateAccount("Tim", 1000));
        accounts.Insert(BankAccountFactory.CreateAccount("Platon", 30000));
        accounts.Insert(BankAccountFactory.CreateAccount("Anna", 25000));
        

        categories.Insert(CategoryFactory.CreateCategory(CategoryType.Expense, "Food"));
        categories.Insert(CategoryFactory.CreateCategory(CategoryType.Income, "Salary"));
        
        // var amount
        var validator = serviceProvider.GetRequiredKeyedService<IOperationValidator>(Validation.Default);
        var headValidator = validator;
        headValidator.Next = serviceProvider.GetRequiredKeyedService<IOperationValidator>(Validation.Account);
        headValidator = headValidator.Next;
        headValidator.Next = serviceProvider.GetRequiredKeyedService<IOperationValidator>(Validation.Category);
        headValidator = headValidator.Next;
        headValidator.Next = serviceProvider.GetRequiredKeyedService<IOperationValidator>(Validation.Amount);
        
        OperationFactory.Validator = validator;

        CommandQueue commands = new();
        var stringDialog = new StringDialog();
        var intDialog = new IntDialog();
        var guidDialog = new GuidDialog();
        var dateDialog = new DateDialog();
        var startDialog = new OptionDialog<CommandType>();
        var categoryTypeDialog = new OptionDialog<CategoryType>();
        var ansDialog = new OptionDialog<Answer>();
        var analyticsDialog = new OptionDialog<AnalitcsType>();
        var formatDialog = new OptionDialog<FileFormat>();
        var modelDialog = new OptionDialog<Model>();

        Console.WriteLine("Welcome to HSE Bank");
        while (true)
        {
            startDialog.Show("How can we be of help today?");
            switch (startDialog.Scan())
            {
                case CommandType.AddBankAccount:
                    stringDialog.Show("Enter name of bank account owner: ");
                    var name = stringDialog.Scan();

                    intDialog.Show("Enter initial bank account balance: ");
                    var balance = intDialog.Scan();
                    
                    commands.Add(new AddAccountCommand(accounts, name, balance));

                    break;
                case CommandType.AddCategory:
                    categoryTypeDialog.Show("Choose category type:");
                    var type = categoryTypeDialog.Scan();

                    stringDialog.Show("Enter name of category: ");
                    name = stringDialog.Scan();

                    commands.Add(new AddCategoryCommand(categories, type, name));
                    break;
                case CommandType.MakeOperation:
                    ansDialog.Show("Do you know account id?");
                    // OptionDialog.Show("Yes", "No");
                    if (ansDialog.Scan() == Answer.No)
                    {
                        var showAccountsCommand = new ShowAccountsCommand(accounts);
                        showAccountsCommand.Execute();
                    }

                    guidDialog.Show("Enter account id: ");
                    var accountId = guidDialog.Scan();

                    ansDialog.Show("Do you know category id?");
                    if (ansDialog.Scan() == Answer.No)
                    {
                        var showCategoriesCommand = new ShowCategoriesCommand(categories);
                        showCategoriesCommand.Execute();
                    }

                    guidDialog.Show("Enter category id: ");
                    var categoryId = guidDialog.Scan();

                    intDialog.Show("Enter operation amount: ");
                    var amount = intDialog.Scan();

                    dateDialog.Show("Enter date of operation: ");
                    var date = dateDialog.Scan();

                    ansDialog.Show("Is there any description for operation?");
                    var description = ansDialog.Scan() == Answer.Yes ? stringDialog.Scan() : null;
                    
                    // commands.Add(new ADd);
                    commands.Add(new AddOperationCommand(operations, accounts, categories, accountId, categoryId, amount, date, description));
                    break;

                case CommandType.Show:
                    modelDialog.Show("What exactly do you want to export?");
                    switch (modelDialog.Scan())
                    {
                        case Model.Account:
                            commands.Add(new ShowAccountsCommand(accounts));
                            break;
                        case Model.Category:
                            commands.Add(new ShowCategoriesCommand(categories));
                            break;
                        case Model.Operation:
                            commands.Add(new ShowOperationsCommand(operations));
                            break;
                    }

                    break;
                case CommandType.Export:
                    modelDialog.Show("What exactly do you want to export?");
                    var modelType = modelDialog.Scan();

                    stringDialog.Show("Enter destination path: ");
                    var pathname = stringDialog.Scan();

                    formatDialog.Show("Enter export format:");
                    IStorageFormatter formatter = formatDialog.Scan() switch
                    {
                        FileFormat.Json => new JsonStorageFormatter(),
                        FileFormat.Csv => new CsvStorageFormatter(),
                    };

                    TextWriter writer = new StreamWriter(pathname);
                    switch (modelType)
                    {
                        case Model.Account:
                            commands.Add(new ExportAccountStorageCommand(accounts, formatter, writer));
                            break;
                        case Model.Category:
                            commands.Add(new ExportCategoryStorageCommand(categories, formatter, writer));
                            break;
                        case Model.Operation:
                            commands.Add(new ExportOperationsStorageCommand(operations, formatter, writer));
                            break;
                    }

                    break;
                case CommandType.Analitics:
                    ansDialog.Show("Do you know account id you want to analyze?");
                    if (ansDialog.Scan() == Answer.No)
                    {
                        var showAccountsCommand = new ShowAccountsCommand(accounts);
                        showAccountsCommand.Execute();
                    }

                    guidDialog.Show("Enter account id: ");
                    accountId = guidDialog.Scan();

                    analyticsDialog.Show("What analytic do you want to make?");
                    switch (analyticsDialog.Scan())
                    {
                        case AnalitcsType.AccountExpence:
                            dateDialog.Show("Enter start date: ");
                            var start = dateDialog.Scan();
                            dateDialog.Show("Enter end date: ");
                            var end = dateDialog.Scan();
                            commands.Add(new DiffCommand(start, end, accountId, operations, categories));
                            break;
                        case AnalitcsType.GroupByCategory:
                            commands.Add(new GroupByCatCommand(accountId, operations, categories));
                            break;
                    }

                    break;
                case CommandType.Quit:
                    Console.WriteLine("Thanks for visiting our bank!");
                    return;
            }


            commands.ExecuteAll();
        }
    }
}