using ExpensesControl.Application.DTOs;
using ExpensesControl.Domain.Entities;

namespace ExpensesControl.Application.Interfaces
{
    public interface IUserService
    {
        Task<User> RegisterAsync(UserRegisterDto dto);
        Task<User?> LoginAsync(UserLoginDto dto);
        Task<User?> GetByEmailAsync(string email);
    }
}