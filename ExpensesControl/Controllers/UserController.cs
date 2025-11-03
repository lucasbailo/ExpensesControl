using ExpensesControl.Application.DTOs;
using ExpensesControl.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesControl.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDto dto)
        {
            try
            {
                var user = await _userService.RegisterAsync(dto);
                return Ok(new
                {
                    message = "Usuário registrado com sucesso!",
                    user = new { user.Id, user.Name, user.Email, user.CreatedAt }
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto dto)
        {
            var user = await _userService.LoginAsync(dto);

            if (user == null)
                return Unauthorized(new { message = "E-mail ou senha inválidos." });

            return Ok(new
            {
                message = "Login realizado com sucesso!",
                user = new { user.Id, user.Name, user.Email }
            });
        }
    }
}
