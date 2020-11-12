using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlazorApp_4.Server.Data;

namespace BlazorApp_4.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeviceTypesController : ControllerBase
    {
        private readonly Digitalshop_V2Context _context;
        public DeviceTypesController(Digitalshop_V2Context context)
        {
            this._context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var types = await _context.TblDeviceTypes.ToListAsync();
            return Ok(types);
        }
       
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var type = new TblDeviceTypes { Typeid = id };
            _context.Remove(type);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpPost]
        public async Task<IActionResult> Post(TblDeviceTypes type)
        {
            _context.Add(type);
            await _context.SaveChangesAsync();
            return Ok(type.Typeid);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            TblDeviceTypes type = await _context.TblDeviceTypes.FirstOrDefaultAsync(t => t.Typeid == id);
            return Ok(type);
        }
        [HttpPut]
        public async Task<IActionResult> Put(TblDeviceTypes type)
        {          
            _context.Entry(type).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
