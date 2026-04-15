using Finance_Application.Models;

namespace Finance_Application.Data.Services;

public interface IIncomeService 
{
    Task <IEnumerable<Income>> GetAll();
    
    Task Add(Income income);

    IQueryable GetChartData();

    Task Delete(int id);
}