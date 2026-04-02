using Finance_Application.Models;
using Microsoft.EntityFrameworkCore;

namespace Finance_Application.Data;

public class FinanceAppContext : DbContext
{
    public FinanceAppContext(DbContextOptions<FinanceAppContext> options):base(options) { }
    
    public DbSet<Expense> Expenses { get; set; }
}