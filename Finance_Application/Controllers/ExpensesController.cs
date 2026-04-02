using Microsoft.AspNetCore.Mvc;
using Finance_Application.Data;

namespace Finance_Application.Controllers;

public class ExpensesController : Controller
{
    private readonly FinanceAppContext _context;

    public ExpensesController(FinanceAppContext context)
    {
        _context = context;
    }
    // GET
    public IActionResult Index()
    {
        return View();
    }
}