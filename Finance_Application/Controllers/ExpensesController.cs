using Microsoft.AspNetCore.Mvc;
using Finance_Application.Data;
using Finance_Application.Data.Services;
using Finance_Application.Models;
using Microsoft.EntityFrameworkCore;

namespace Finance_Application.Controllers;

public class ExpensesController : Controller
{
    private readonly IExpensesService _expensesService;

    public ExpensesController(IExpensesService expensesService)
    {
        _expensesService = expensesService;
    }
    // GET
    public async Task <IActionResult> Index()
    {
        var expenses = await _expensesService.GetAll();
        return View(expenses);
    }

    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    public async Task <IActionResult> Create(Expense expense)
    {
        if (ModelState.IsValid)
        {
            await _expensesService.Add(expense);
            
            return RedirectToAction("Index");
        }
        return View();
    }

    public IActionResult GetChart()
    {
        var data = _expensesService.GetChartData();
        return Json(data);
    }
}