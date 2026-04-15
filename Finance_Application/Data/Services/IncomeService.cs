using Finance_Application.Models;
using Microsoft.EntityFrameworkCore;

namespace Finance_Application.Data.Services;

public class IncomeService : IIncomeService
{
    private readonly FinanceAppContext _context;
     
    public IncomeService(FinanceAppContext context)
    {
        _context = context;
    }
        
    public async Task<IEnumerable<Income>> GetAll()
    {
        var income = await _context.Income.ToListAsync();
        return income;
    }

    public async Task Add(Income income)
    {
        _context.Income.Add(income);
        await _context.SaveChangesAsync();
    }

    public IQueryable GetChartData()
    {
        var data = _context.Income.GroupBy(e => e.Category)
            .Select(g => new
            {
                Category = g.Key,
                Total = g.Sum(e => e.Amount),
            });
        
        return data;
    }
}