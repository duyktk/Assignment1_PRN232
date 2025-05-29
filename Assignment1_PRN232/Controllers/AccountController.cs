using CoreApiResponse;
using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Assignment1_PRN232.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseController
    {
        private readonly AccountService _accountService;

        public AccountController(AccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet("Login")]
        public async Task<IActionResult> Login(string email, string password)
        {
            var user = await _accountService.Login(email, password);
            if (user == null) return CustomResult("Wrong email or password.");
            return CustomResult(user);
        }

        [HttpGet("GetAccountById/{id}")]
        public async Task<IActionResult> GetAccountById(short id)
        {
            return CustomResult(await _accountService.GetAccountById(id));
        }

        [HttpPost("CreateAccount")]
        public async Task<IActionResult> CreateAccount(string Fullname, string Email, string Password, int Role)
        {
            if (await _accountService.CreateAccount(Fullname, Email, Password, Role)) return CustomResult("Registed successfully.");
            return CustomResult("Email existed.");
        }

        [HttpDelete("DeleteAccount")]
        public async Task<IActionResult> DeleteAccount(short id)
        {
            if (await _accountService.RemoveAccount(id)) return CustomResult("Successfully");
            return CustomResult("Failed");
        }

        [HttpPut("UpdateAccount/{id}")]
        public async Task<IActionResult> UpdateAccount(short id, string? Fullname, string? Email, string? Password, int? Role)
        {
            if (await _accountService.UpdateAccount(id, Fullname, Email, Password, Role)) return CustomResult("Successfully");
            return CustomResult("Failed");
        }

    }
}
