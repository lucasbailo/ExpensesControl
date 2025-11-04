using ExpensesControl.Application.DTOs;
using ExpensesControl.Domain.Entities;

namespace ExpensesControl.Application.Interfaces
{
    public interface IExpenseService
    {
        Task<IEnumerable<Expense>> GetAllByUserAsync(Guid userId);
        Task<Expense> CreateAsync(Guid userId, ExpenseCreateDto dto);
        Task<Expense?> UpdateAsync(Guid userId, ExpenseUpdateDto dto);
        Task<bool> DeleteAsync(Guid userId, Guid expenseId);
    }
}
