using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepoPatternAPI.Models;

namespace RepoPatternAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly InventoryContext _context;

        public MenuController(InventoryContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<Menu>>> GetMenus()
        {
            return await _context.Menus
                .Include(m => m.SubMenus)
                .Include(m => m.MenuRoles)
                .ThenInclude(mr => mr.Role)
                .ToListAsync();
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public async Task<ActionResult<Menu>> CreateMenu(Menu menu)
        {
            _context.Menus.Add(menu);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMenus), new { id = menu.Id }, menu);
        }


    }
}
