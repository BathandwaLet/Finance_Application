using Finance_Application.Models;
using Microsoft.EntityFrameworkCore;

namespace Finance_Application.Data.Services;

public class ExpensesService : IExpensesService
{
    private readonly FinanceAppContext _context;
     
    public ExpensesService(FinanceAppContext context)
    {
        _context = context;
    }
        
    public async Task<IEnumerable<Expense>> GetAll()
    {
        var expenses = await _context.Expenses.ToListAsync();
        return expenses;
    }

    public async Task Add(Expense expense)
    {
        _context.Expenses.Add(expense);
       await _context.SaveChangesAsync();
    }
}