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
    public class DeviceUsageController : ControllerBase
    {
        private readonly Digitalshop_V2Context _context;
        public DeviceUsageController(Digitalshop_V2Context context)
        {
            this._context = context;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            
            TblDeviceUsage usage = await _context.TblDeviceUsage.FirstOrDefaultAsync(u => u.IsActive.HasValue && u.IsActive.Value && u.Deviceid == id);
            if (usage != null && usage.Assigneduserid.HasValue)
                return Ok(usage);
            else
                return Ok(new TblDeviceUsage());

        }
       
    }
}
