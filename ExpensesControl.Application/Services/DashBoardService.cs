using ExpensesControl.Application.Interfaces;
using ExpensesControl.Application.DTOs;

public class DashboardService : IDashboardService
{
    private readonly IExpenseService _expenseService;

    public DashboardService(IExpenseService expenseService)
    {
        _expenseService = expenseService;
    }

    public async Task<ExpenseDashboardDto> GetDashboardAsync(Guid userId)
    {
        var expenses = await _expenseService.GetAllByUserAsync(userId);

        return new ExpenseDashboardDto
        {
            TotalByType = expenses
                .GroupBy(e => e.Type)
                .ToDictionary(g => g.Key, g => g.Sum(x => x.Amount)),

            MonthlyTotals = expenses
                .GroupBy(e => e.Date.ToString("yyyy-MM"))
                .OrderBy(g => g.Key)
                .ToDictionary(g => g.Key, g => g.Sum(x => x.Amount))
        };
    }
}
