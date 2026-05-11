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

    public async Task Delete(int id)
    {
        var income = await _context.Income.FindAsync(id);
        if (income != null)
        {
            _context.Income.Remove(income);
            await _context.SaveChangesAsync();
        }
    }

    public async Task Update(Income income)
    {
        _context.Income.Update(income);
        await _context.SaveChangesAsync();
    }
    
    public async Task<Income> GetById(int id)
    {
        return await _context.Income.FindAsync(id);
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