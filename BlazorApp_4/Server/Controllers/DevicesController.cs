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
    public class DevicesController : ControllerBase
    {
        private readonly Digitalshop_V2Context _context;
        public DevicesController(Digitalshop_V2Context context)
        {
            this._context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Get() {
            var devices = await _context.VGetAllDevices.ToListAsync();
            return Ok(devices);
        }
    }
}
