using ExpensesControl.Application.DTOs;
using ExpensesControl.Application.Interfaces;
using ExpensesControl.Domain.Entities;
using ExpensesControl.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ExpensesControl.Application.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly AppDbContext _context;

        public ExpenseService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Expense>> GetAllByUserAsync(Guid userId)
        {
            return await _context.Expenses
                .Where(e => e.UserId == userId)
                .OrderByDescending(e => e.Date)
                .ToListAsync();
        }

        public async Task<Expense> CreateAsync(Guid userId, ExpenseCreateDto dto)
        {
            var expense = new Expense
            {
                UserId = userId,
                Type = dto.Type,
                Description = dto.Description,
                Amount = dto.Amount,
                Date = dto.Date
            };

            _context.Expenses.Add(expense);
            await _context.SaveChangesAsync();
            return expense;
        }

        public async Task<Expense?> UpdateAsync(Guid userId, ExpenseUpdateDto dto)
        {
            var expense = await _context.Expenses
                .FirstOrDefaultAsync(e => e.Id == dto.Id && e.UserId == userId);

            if (expense == null)
                return null;

            expense.Type = dto.Type;
            expense.Description = dto.Description;
            expense.Amount = dto.Amount;
            expense.Date = dto.Date;

            await _context.SaveChangesAsync();
            return expense;
        }

        public async Task<bool> DeleteAsync(Guid userId, Guid expenseId)
        {
            var expense = await _context.Expenses
                .FirstOrDefaultAsync(e => e.Id == expenseId && e.UserId == userId);

            if (expense == null)
                return false;

            _context.Expenses.Remove(expense);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
