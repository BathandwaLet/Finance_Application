using Finance_Application.Models;

namespace Finance_Application.Data.Services;

public interface IExpensesService
{
    Task <IEnumerable<Expense>> GetAll();
    
    Task Add(Expense expense);
}