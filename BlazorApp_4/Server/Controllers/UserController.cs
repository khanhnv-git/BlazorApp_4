using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlazorApp_4.Server.Data;

namespace BlazorApp_4.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly Digitalshop_V2Context _context;
        public UserController(Digitalshop_V2Context context)
        {
            this._context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Get() 
        {
            var users = await _context.TblUsers.Where(u => u.Enabled.HasValue && u.Enabled.Value).ToArrayAsync();
            return Ok(users);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) {
            var user = await _context.TblUsers.SingleOrDefaultAsync(u => u.UserId == id);
            return Ok(user);
        }
    }
}
