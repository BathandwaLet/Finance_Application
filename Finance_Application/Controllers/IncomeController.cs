using Microsoft.AspNetCore.Mvc;
using Finance_Application.Data;
using Finance_Application.Data.Services;
using Finance_Application.Models;
using Microsoft.EntityFrameworkCore;

namespace Finance_Application.Controllers;

public class IncomeController : Controller
{
    private readonly IIncomeService _incomeService;

    public IncomeController(IIncomeService incomeService)
    {
        _incomeService = incomeService;
    }
    // GET
    public async Task <IActionResult> Index()
    {
        var income = await _incomeService.GetAll();
        return View(income);
    }

    //POST
    public IActionResult Create()
    {
        ViewBag.Categories = new List<string>
        {
            "Salary/Wages",
            "Stipend",
            "Grant",
            "Gambling/Lottery Winnings",
            "Interest",
            "Dividends",
            "Other"
        };
        return View();
    }
    
    [HttpPost]
    public async Task <IActionResult> Create(Income income)
    {
        if (ModelState.IsValid)
        {
            await _incomeService.Add(income);
            
            return RedirectToAction("Index");
        }
        
        ViewBag.Categories = new List<string>
        {
            "Salary/Wages",
            "Stipend",
            "Grant",
            "Gambling/Lottery Winnings",
            "Interest",
            "Dividends",
            "Other"
        };
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        await _incomeService.Delete(id);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Income income)
    {
        if (ModelState.IsValid)
        {
            await _incomeService.Update(income);
            return RedirectToAction("Index");
        }
        return View(income);
    }
    
    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var income = await _incomeService.GetById(id);
        
        ViewBag.Categories = new List<string>
        {
            "Salary/Wages",
            "Stipend",
            "Grant",
            "Gambling/Lottery Winnings",
            "Interest",
            "Dividends",
            "Other"
        };
        
        return View(income);
    }

    public IActionResult GetChart()
    {
        var data = _incomeService.GetChartData();
        return Json(data);
    }
}