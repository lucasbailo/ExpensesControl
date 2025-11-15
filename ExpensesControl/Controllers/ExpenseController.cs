using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using ExpensesControl.Application.DTOs;
using ExpensesControl.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesControl.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ExpenseController : ControllerBase
    {
        private readonly IExpenseService _expenseService;

        private readonly IDashboardService _dashboardService;

        public ExpenseController(
            IExpenseService expenseService,
            IDashboardService dashboardService)
        {
            _expenseService = expenseService;
            _dashboardService = dashboardService;
        }

        // 🔹 Recupera o ID do usuário logado a partir do token
        private Guid GetUserId()
        {
            var userIdClaim = User.FindFirstValue(JwtRegisteredClaimNames.Sub)
                             ?? User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userIdClaim))
                throw new UnauthorizedAccessException("Usuário não identificado no token.");

            return Guid.Parse(userIdClaim);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var userId = GetUserId();
            var expenses = await _expenseService.GetAllByUserAsync(userId);
            return Ok(expenses);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ExpenseCreateDto dto)
        {
            var userId = GetUserId();
            var expense = await _expenseService.CreateAsync(userId, dto);
            return Ok(expense);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] ExpenseUpdateDto dto)
        {
            var userId = GetUserId();
            var expense = await _expenseService.UpdateAsync(userId, dto);
            if (expense == null)
                return NotFound(new { message = "Despesa não encontrada." });
            return Ok(expense);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var userId = GetUserId();
            var deleted = await _expenseService.DeleteAsync(userId, id);
            if (!deleted)
                return NotFound(new { message = "Despesa não encontrada." });
            return NoContent();
        }

        [HttpGet("dashboard")]
        public async Task<IActionResult> GetDashboard()
        {
            var userId = GetUserId();
            var dashboard = await _dashboardService.GetDashboardAsync(userId);
            return Ok(dashboard);
        }
    }
}
