using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TravelAgency.REST.DTOs;
using TravelAgency.REST.Models;

namespace TravelAgency.REST.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthController(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto model)
        {
            if (!await _roleManager.RoleExistsAsync(model.Role))
            {
                await _roleManager.CreateAsync(
                    new IdentityRole(model.Role));
            }

            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email
            };

            var result =
                await _userManager.CreateAsync(
                    user,
                    model.Password);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            await _userManager.AddToRoleAsync(
                user,
                model.Role);

            return Ok("User registered");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto model)
        {
            var user =
                await _userManager.FindByEmailAsync(
                    model.Email);

            if (user == null)
                return Unauthorized();

            var valid =
                await _userManager.CheckPasswordAsync(
                    user,
                    model.Password);

            if (!valid)
                return Unauthorized();

            var roles =
                await _userManager.GetRolesAsync(user);

            return Ok(new
            {
                Message = "Login successful",
                User = user.Email,
                Roles = roles
            });
        }
    }
}