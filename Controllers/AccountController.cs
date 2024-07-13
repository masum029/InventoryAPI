using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RepoPatternAPI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RepoPatternAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly InventoryContext _context;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IConfiguration configuration,
            InventoryContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _context = context; 
        }

        //[HttpPost("register")]
        //public async Task<IActionResult> Register([FromBody] RegisterModel model)
        //{
        //    var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
        //    var result = await _userManager.CreateAsync(user, model.Password);

        //    if (result.Succeeded)
        //    {
        //        return Ok(new { result = "User created successfully!" });
        //    }

        //    return BadRequest(result.Errors);
        //}

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return CreatedAtAction(nameof(Register), new { id = user.Id }, new { result = "User created successfully!" });
            }

            return BadRequest(result.Errors);
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

            if (result.Succeeded)
            {
                var appUser = await _userManager.FindByEmailAsync(model.Email);
                var token = GenerateJwtToken(appUser);
                return Ok(new { token });
            }

            return Unauthorized();
        }

        private string GenerateJwtToken(ApplicationUser user)
        {
            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.NameIdentifier, user.Id)
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["Jwt:ExpireMinutes"])),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpGet("user-menus")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Menu>>> GetUserMenus()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(userId);
            var roles = await _userManager.GetRolesAsync(user);

            var menus = await _context.Menus
                .Include(m => m.SubMenus)
                .Include(m => m.MenuRoles)
                .ThenInclude(mr => mr.Role)
                .Where(m => m.MenuRoles.Any(mr => roles.Contains(mr.Role.Name)))
                .ToListAsync();

            return Ok(menus);
        }
    }
}
